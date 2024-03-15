using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;
using System.Collections.Generic;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class OrderItemBLL : BaseBusinessObject<OrderItem, OrderItemModelFilter, long>
    {
        public new OrderItemDAO data { get; set; }
        public OrderItemBLL() : base(new OrderItemDAO())
        {
            data = new OrderItemDAO();
        }

        public List<OrderItem> InsertList(List<OrderItem> list)
        {
            return data.InsertList(list);
        }

        public List<OrderItem> UpdateList(List<OrderItem> list)
        {
            return data.UpdateList(list);
        }

        public List<OrderItem> ListByOrderId(long orderId)
        {
            return data.ListByOrderId(orderId);
        }
    }
}