using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Controllers.ModelRequest;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [AllowAnonymous]
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
        [Route("{id}")]
        public override ActionResult<Order> GetById(long id)
        {
            try
            {
                Console.WriteLine("teste");
                return new ObjectResult(new { error = "Foi - " + id.ToString() }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ObjectResult(new { error = ex.ToString() }) { StatusCode = 200 };
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

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}/Numbers")]
        public ActionResult<List<int>> ListNumberById(long id)
        {
            return new OrderBLL().ListNumberById(id);
        }
    }
}
