using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class OrderLogDAO : BaseDataAccessObject<OrderLog, OrderLogModelFilter, long>
    {
        public OrderLogDAO()
        {
            MySQLConnection = new MySQLContext<OrderLog>();
        }
    }
}
