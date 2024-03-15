using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;
using MySql.Data.MySqlClient;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class OrderBLL : BaseBusinessObject<Order, OrderModelFilter, long>
    {
        public new OrderDAO data { get; set; }
        public OrderBLL() : base(new OrderDAO())
        {
            data = new OrderDAO();
        }

        public List<Customer> ListCustomerByFilter(RaffleCustomerModelFilter filter)
        {
            return data.ListCustomerByFilter(filter);
        }

        public Order UpdateOrderStatus(long id, Enums.EOrderStatus orderStatusId)
        {
            return data.UpdateOrderStatus(id, orderStatusId);
        }

        public List<int?> ListNumberById(long id)
        {
            return data.ListNumberById(id);
        }
    }
}