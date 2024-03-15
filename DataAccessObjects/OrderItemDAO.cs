using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class OrderItemDAO : BaseDataAccessObject<OrderItem, OrderItemModelFilter, long>
    {
        public OrderItemDAO()
        {
            MySQLConnection = new MySQLContext<OrderItem>();
        }

        public List<OrderItem> InsertList(List<OrderItem> list)
        {
            using var context = MySQLConnection;
            context.Table.AddRange(list);
            context.SaveChanges();
            return list;
        }

        public List<OrderItem> UpdateList(List<OrderItem> list)
        {
            using var context = MySQLConnection;
            context.Table.UpdateRange(list);
            context.SaveChanges();
            return list;
        }

        public List<OrderItem> ListByOrderId(long orderId)
        {
            var context = MySQLConnection;
            return [.. (from t in context.Table where t.OrderId == orderId select t).OrderByDescending(x => x.DateInserted)];
        }
    }
}
