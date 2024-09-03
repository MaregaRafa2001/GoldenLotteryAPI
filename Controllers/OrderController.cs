using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Controllers.ModelRequest;
using GoldenLotteryAPI.Models;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using static GoldenLotteryAPI.Core.Enums;

namespace GoldenLotteryAPI.Controllers
{
    public class OrderController : BaseController<Order, OrderModelFilter, long>
    {
        public new OrderBLL business { get; set; }
        public OrderController() : base(new OrderBLL())
        {
            business = new OrderBLL();
        }

        [HttpPatch]
        [Route("{id}/Status")]
        public ActionResult<Order> UpdateStatus(long id, [FromBody] OrderUpdateStatusModelRequest request)
        {
            var order = business.GetById(id);

            new OrderLogBLL().Insert(new()
            {
                Description = $"Status alterado de: '{order.OrderStatusId}' para: '{request.OrderStatusId}'. Descrição: {request.Description}",
                OrderId = id,
                OrderLogEventTypeId = EOrderLogEventTypes.Updated,
                InsertedBy = 1
            });

            order.OrderStatusId = request.OrderStatusId;
            business.UpdateOrderStatus(id, request.OrderStatusId);
            return order;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Detail/{id}")]
        public async Task<object> GetDetailById(long id)
        {
            var order = business.GetById(id);

            switch (order.OrderStatusId)
            {
                case EOrderStatus.WaitingPayment:
                    string paymentHtml = "";
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(order.ImageUrlPaymentDetail);
                        if (response.IsSuccessStatusCode)
                            paymentHtml = await response.Content.ReadAsStringAsync();
                    }
                    return new { order, paymentHtml };

                case EOrderStatus.Paid:
                    var numbers = new OrderItemBLL().ListByOrderId(order.OrderId).Select(x => x.Number).ToList();
                    return new { order, numbers };

                default:
                case EOrderStatus.Canceled:
                    return order;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public override ActionResult<List<Order>> ListByFilter(OrderModelFilter filter)
        {
            return base.ListByFilter(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}/Logs")]
        public ActionResult<List<OrderLog>> ListLogByFilter(long id, [FromQuery] OrderLogModelFilter filter)
        {
            filter.OrderId = id;
            return new OrderLogBLL().ListByFilter(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Status")]
        public ActionResult<List<SelectOption>> ListOrderStatus()
        {
            return Enum.GetValues(typeof(EOrderStatus)).Cast<EOrderStatus>()
                .Select(status => new SelectOption
                {
                    Value = (int)status,
                    Text = status.ToString()
                })
                .ToList();
        }

        [HttpPost]
        [Route("Payment")]
        [AllowAnonymous]
        public ActionResult<CreatePaymentPixModelResponse> CreatePayment([FromBody] OrderCreatePaymentModelRequest model)
        {
            // verify if has orderItems
            if (model.QuantityNumbers < 1)
                throw new ApplicationException("Selecione a quantidade de bilhetes que deseja comprar.");

            //get details about the Raffle
            Raffle raffle = new RaffleBLL().GetById(model.RaffleId);
            if (raffle == null || raffle?.RaffleId == 0)
                throw new ApplicationException("Rifa não encontrada.");

            // initialize order
            Order order = new()
            {
                DatePayment = null,
                RaffleId = model.RaffleId,
                CustomerId = model.CustomerId,
                OrderStatusId = EOrderStatus.WaitingPayment,
                Price = model.QuantityNumbers * raffle.Price,
            };
            base.Insert(order);

            // insert foreach orderItem
            order.OrderItems = [];
            for (int i = 0; i < model.QuantityNumbers; i++)
            {
                order.OrderItems.Add(new()
                {
                    OrderId = order.OrderId,
                    Price = raffle.Price
                });
            }

            new OrderItemBLL().InsertList(order.OrderItems);

            // create payment on MercadoPago
            Payment payment = CreateMercadoPagoPayment(order);

            // if return error
            if (payment.ApiResponse.StatusCode != 201)
                return new ObjectResult(new { error = "Erro ao criar pagamento." }) { StatusCode = 500 };

            // else save image of payment details
            dynamic responseContent = JsonConvert.DeserializeObject(payment.ApiResponse.Content);
            order.ImageUrlPaymentDetail = responseContent.point_of_interaction.transaction_data.ticket_url;
            order.LastMercadoPagoId = responseContent.id;
            business.Update(order);

            // return success
            return new ObjectResult(new { orderId = order.OrderId }) { StatusCode = 201 };
        }

        static Payment CreateMercadoPagoPayment(Order order)
        {
            Customer customer = new CustomerBLL().GetById(order.CustomerId);
            MercadoPagoConfig.AccessToken = "APP_USR-1069429511000603-083016-eb249d468541d967fa660e0c20cc5ebb-387733480";

            // Criar um objeto de pagamento
            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = order.Price,
                Description = $"BubuPrêmios - Pedido #{order.OrderId.ToString().PadLeft(5, '0')}",
                Installments = 1,
                AdditionalInfo = new PaymentAdditionalInfoRequest()
                {
                    Items = new List<PaymentItemRequest>()
                    {
                        new()
                        {
                            Id = order.OrderId.ToString()
                        }
                    }
                },
                PaymentMethodId = "pix",
                Payer = new PaymentPayerRequest
                {
                    Email = customer.Email,
                    Identification = new IdentificationRequest
                    {
                        Type = "CPF",
                        Number = customer.CPF
                    },
                }
            };

            var client = new PaymentClient();
            return client.Create(paymentRequest);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}/Numbers")]
        public ActionResult<List<int?>> ListNumberById(long id)
        {
            return new OrderBLL().ListNumberById(id);
        }
    }
}
