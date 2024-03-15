using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class RaffleDAO : BaseDataAccessObject<Raffle, RaffleModelFilter, long>
    {
        public RaffleDAO()
        {
            MySQLConnection = new MySQLContext<Raffle>();
        }

        public override List<Raffle> ListByFilter(RaffleModelFilter filter)
        {
            using var context = MySQLConnection;
            return [.. (
                from t in context.Table
                where (string.IsNullOrWhiteSpace(filter.Title) || t.Title.Contains(filter.Title.ToLower())) && (filter.RaffleStatusId == null || t.RaffleStatusId == filter.RaffleStatusId)
                select t)
                    .OrderByDescending(x => x.DateInserted)
                    .Skip((filter.RecordsPerPage * filter.Page) - filter.RecordsPerPage)
                    .Take(filter.RecordsPerPage)];
        }

        public List<int> ListSortedNumbersById(long raffleId)
        {
            using var context = MySQLConnection;
            return [.. (
                from t in context.Table
                join o in context.Set<Order>() on t.RaffleId equals o.RaffleId
                join oi in context.Set<OrderItem>() on o.OrderId equals oi.OrderId
                where t.RaffleId == raffleId && o.OrderStatusId == GoldenLotteryAPI.Core.Enums.EOrderStatus.Paid && oi.Number != null
                select oi.Number.Value
                )];
        }
    }
}