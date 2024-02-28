using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class OrderItemBLL : BaseBusinessObject<OrderItem, OrderItemModelFilter, long>
    {
        public new OrderItemDAO data { get; set; }
        public OrderItemBLL() : base(new OrderItemDAO())
        {
            data = new OrderItemDAO();
        }
    }
}