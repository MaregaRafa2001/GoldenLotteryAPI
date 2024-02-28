using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class RaffleCustomerBLL : BaseBusinessObject<RaffleCustomer, RaffleCustomerModelFilter, long>
    {
        public new RaffleCustomerDAO data { get; set; }
        public RaffleCustomerBLL() : base(new RaffleCustomerDAO())
        {
            data = new RaffleCustomerDAO();
        }

        public List<Customer> ListCustomerByFilter(RaffleCustomerModelFilter filter)
        {
            return new RaffleCustomerDAO().ListCustomerByFilter(filter);
        }
    }
}