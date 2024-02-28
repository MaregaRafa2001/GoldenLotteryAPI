using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class AdministratorDAO : BaseDataAccessObject<Administrator, AdministratorModelFilter, long>
    {
        public AdministratorDAO()
        {
            MySQLConnection = new MySQLContext<Administrator>();
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            using var context = MySQLConnection;
            return context.Table.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
        }
    }
}
