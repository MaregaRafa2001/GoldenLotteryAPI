using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.DataAccessObjects
{
    public class RaffleCustomerDAO : BaseDataAccessObject<RaffleCustomer, RaffleCustomerModelFilter, long>
    {
        public RaffleCustomerDAO()
        {
            MySQLConnection = new MySQLContext<RaffleCustomer>();
        }

        public List<Customer> ListCustomerByFilter(RaffleCustomerModelFilter filter)
        {
            using var context = MySQLConnection;
            return
                [
                    .. (
                    from rc in context.Table
                    join c in context.Set<Customer>() on rc.CustomerId equals c.CustomerId
                    where rc.RaffleId == filter.RaffleId && (string.IsNullOrWhiteSpace(filter.CustomerName) || c.Name.Contains(filter.CustomerName.ToLower()))
                    select new Customer
                    {
                        CustomerId = c.CustomerId,
                        Name = c.Name,
                        CPF = c.CPF,
                        Email = c.Email,
                        Password = c.Password,
                        BirthDate = c.BirthDate
                    }).Skip((filter.RecordsPerPage * filter.Page) - filter.RecordsPerPage).Take(filter.RecordsPerPage)
                ];
        }
    }
}
