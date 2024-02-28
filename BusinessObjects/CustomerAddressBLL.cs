using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class CustomerAddressBLL : BaseBusinessObject<CustomerAddress, CustomerAddressModelFilter, long>
    {
        public new CustomerAddressDAO data { get; set; }
        public CustomerAddressBLL() : base(new CustomerAddressDAO())
        {
            data = new CustomerAddressDAO();
        }
    }
}