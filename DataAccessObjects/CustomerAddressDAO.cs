using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class CustomerAddressDAO : BaseDataAccessObject<CustomerAddress, CustomerAddressModelFilter, long>
    {
        public CustomerAddressDAO()
        {
            MySQLConnection = new MySQLContext<CustomerAddress>();
        }
    }
}
