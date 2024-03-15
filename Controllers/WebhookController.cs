using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.ModelRequest;
using GoldenLotteryAPI.Models;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Http;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GoldenLotteryAPI.Controllers
{
    [Route("Webhook")]
    public class WebhookController
    {
        [HttpPost]
        [Route("MercadoPago/PaymentListener")]
        public async Task<IActionResult> MercadoPagoPaymentListener([FromBody] dynamic body)
        {
            long? orderId = null;
            long? mercadoPagoId = null;
            OrderLogBLL orderLogBLL = new();

            try
            {
                MercadoPagoWebhookResponse response = JsonSerializer.Deserialize<MercadoPagoWebhookResponse>(body);

                JsonElement dataElement = (JsonElement)response.data;
                if (dataElement.TryGetProperty("id", out var idElement) && idElement.ValueKind == JsonValueKind.String)
                    mercadoPagoId = long.Parse(idElement.GetString());
                else
                    throw new ApplicationException("Id do pagamento não foi encontrado.");

                if (response.action == "payment.updated")
                {
                    OrderBLL orderBLL = new();
                    RaffleBLL raffleBLL = new();
                    OrderItemBLL orderItemBLL = new();

                    // get the details of mercadoPagoPayment
                    Payment payment = GetMercadoPagoPaymentById(mercadoPagoId.Value);

                    if (payment.AdditionalInfo.Items is null || payment.AdditionalInfo.Items?.Count < 1)
                        throw new ApplicationException("Pagamento sem informações adicionais, não foi possivel resgatar o número do pedido. Entre em contato com o suporte.");

                    // get the order
                    orderId = long.Parse(payment.AdditionalInfo.Items[0].Id);
                    Order order = orderBLL.GetById(orderId.Value);

                    // validate payment status
                    if (payment.Status != "approved")
                        throw new ApplicationException($"{mercadoPagoId} - Webhook recebido com o status '{payment.Status}'.");

                    // validate order status
                    if (order.OrderStatusId == GoldenLotteryAPI.Core.Enums.EOrderStatus.Paid)
                        throw new ApplicationException($"{mercadoPagoId} - O pedido já está com o status 'Pago'.");

                    // update order status
                    orderBLL.UpdateOrderStatus(orderId.Value, GoldenLotteryAPI.Core.Enums.EOrderStatus.Paid);

                    // get raffle details
                    Raffle raffle = raffleBLL.GetById(order.RaffleId);

                    //get available and unavailable numbers
                    List<int> availableNumbers = Enumerable.Range(1, raffle.NumberRange).ToList();
                    List<int> unavailableNumbers = raffleBLL.ListSortedNumbersById(raffle.RaffleId);
                    availableNumbers.RemoveAll(b => unavailableNumbers.Contains(b));

                    // get orderItems from Order
                    List<OrderItem> orderItems = orderItemBLL.ListByOrderId(orderId.Value);

                    // sort a number for each orderItem
                    orderItems.ForEach(item =>
                    {
                        item.Number = SortNumber(availableNumbers);
                    });

                    // update OrderItems
                    orderItemBLL.UpdateList(orderItems);

                    orderLogBLL.Insert(new()
                    {
                        OrderId = orderId ?? 0,
                        DateInserted = DateTime.Now,
                        Description = $"{mercadoPagoId} - Transferência de pix no valor de R$ {payment.TransactionAmount.Value:C} recebida com sucesso",
                        OrderLogEventTypeId = GoldenLotteryAPI.Core.Enums.EOrderLogEventTypes.WebhookSuccess
                    });
                }
                return new OkObjectResult("");
            }
            catch (Exception ex)
            {
                orderLogBLL.Insert(new()
                {
                    OrderId = orderId ?? 0,
                    DateInserted = DateTime.Now,
                    Description = $"{mercadoPagoId} - {ex.Message}",
                    OrderLogEventTypeId = GoldenLotteryAPI.Core.Enums.EOrderLogEventTypes.WebhookFailure
                });

                throw;
            }
        }

        Payment GetMercadoPagoPaymentById(long id)
        {
            MercadoPagoConfig.AccessToken = "APP_USR-5461696117860348-031117-cdc72963cf9e58300b6850cb179d875e-195188072";
            var client = new PaymentClient();
            return client.Get(id);
        }

        static int SortNumber(List<int> availableNumbers)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, availableNumbers.Count);
            int sortedNumber = availableNumbers[randomIndex];
            availableNumbers.RemoveAt(randomIndex);

            return sortedNumber;
        }
    }
}
