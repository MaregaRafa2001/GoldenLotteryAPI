using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class OrderItemDAO : BaseDataAccessObject<OrderItem, OrderItemModelFilter, long>
    {
        public OrderItemDAO()
        {
            MySQLConnection = new MySQLContext<OrderItem>();
        }
    }
}
