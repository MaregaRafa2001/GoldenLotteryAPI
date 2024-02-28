using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class CustomerBLL : BaseBusinessObject<Customer, CustomerModelFilter, long>
    {
        public new CustomerDAO data { get; set; }
        public CustomerBLL() : base(new CustomerDAO())
        {
            data = new CustomerDAO();
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            return data.GetByEmailAndPassword(email, password);
        }
    }
}