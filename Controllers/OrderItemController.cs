using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class OrderItemController : BaseController<OrderItem, OrderItemModelFilter, long>
    {
        public new OrderItemBLL business { get; set; }
        public OrderItemController() : base(new OrderItemBLL())
        {
            business = new OrderItemBLL();
        }
    }
}
