using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class OrderDAO : BaseDataAccessObject<Order, OrderModelFilter, long>
    {
        public OrderDAO()
        {
            MySQLConnection = new MySQLContext<Order>();
        }

        public Order UpdateOrderStatus(long id, Enums.EOrderStatus orderStatusId)
        {
            using var context = MySQLConnection;
            var order = context.Table.Find(id) ?? throw new RegisterNotFoundException();

            // if status is paid then set datePayment now else set null
            order.DatePayment = orderStatusId == Enums.EOrderStatus.Paid ? DateTime.Now : null;
            order.OrderStatusId = orderStatusId;
            context.SaveChanges();
            return order;
        }

        public List<Customer> ListCustomerByFilter(RaffleCustomerModelFilter filter)
        {
            using var context = MySQLConnection;
            return [.. (from o in context.Table
                        join c in context.Set<Customer>() on o.CustomerId equals c.CustomerId
                        where o.RaffleId == filter.RaffleId
                        select new Customer
                        {
                            CustomerId = c.CustomerId,
                            Name = c.Name,
                            CPF = c.CPF,
                            Email = c.Email,
                            Password = c.Password,
                            BirthDate = c.BirthDate
                        }).Distinct()
                    ];
        }

        public List<int> ListNumberById(long id)
        {
            using var context = MySQLConnection;
            return [.. (from o in context.Table
                        join oi in context.Set<OrderItem>() on o.OrderId equals oi.OrderId
                        where o.OrderId == id
                        select oi.Number)
                    ];
        }
    }
}
