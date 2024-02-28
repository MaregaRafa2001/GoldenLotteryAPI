using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class RaffleImageDAO : BaseDataAccessObject<RaffleImage, RaffleImageModelFilter, long>
    {
        public RaffleImageDAO()
        {
            MySQLConnection = new MySQLContext<RaffleImage>();
        }
    }
}
