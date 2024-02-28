using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class OrderLogBLL : BaseBusinessObject<OrderLog, OrderLogModelFilter, long>
    {
        public new OrderLogDAO data { get; set; }
        public OrderLogBLL() : base(new OrderLogDAO())
        {
            data = new OrderLogDAO();
        }
    }
}