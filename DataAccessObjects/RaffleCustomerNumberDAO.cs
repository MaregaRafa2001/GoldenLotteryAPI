using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class RaffleCustomerNumberDAO : BaseDataAccessObject<RaffleCustomerNumber, RaffleCustomerNumberModelFilter, long>
    {
        public RaffleCustomerNumberDAO()
        {
            MySQLConnection = new MySQLContext<RaffleCustomerNumber>();
        }
    }
}
