using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class CustomerDAO : BaseDataAccessObject<Customer, CustomerModelFilter, long>
    {
        public CustomerDAO()
        {
            MySQLConnection = new MySQLContext<Customer>();
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            using var context = MySQLConnection;
            return context.Table.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
        }
    }
}
