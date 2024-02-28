using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class WinningRaffleNumberDAO : BaseDataAccessObject<WinningRaffleNumber, WinningRaffleNumberModelFilter, long>
    {
        public WinningRaffleNumberDAO()
        {
            MySQLConnection = new MySQLContext<WinningRaffleNumber>();
        }
    }
}
