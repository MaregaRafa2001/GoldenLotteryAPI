using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class OrderLogController : BaseController<OrderLog, OrderLogModelFilter, long>
    {
        public new OrderLogBLL business { get; set; }
        public OrderLogController() : base(new OrderLogBLL())
        {
            business = new OrderLogBLL();
        }
    }
}
