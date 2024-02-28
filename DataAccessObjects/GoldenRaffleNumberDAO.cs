using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class GoldenRaffleNumberDAO : BaseDataAccessObject<GoldenRaffleNumber, GoldenRaffleNumberModelFilter, long>
    {
        public GoldenRaffleNumberDAO()
        {
            MySQLConnection = new MySQLContext<GoldenRaffleNumber>();
        }
    }
}
