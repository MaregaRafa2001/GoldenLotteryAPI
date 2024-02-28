using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class RaffleCustomerNumberBLL : BaseBusinessObject<RaffleCustomerNumber, RaffleCustomerNumberModelFilter, long>
    {
        public new RaffleCustomerNumberDAO data { get; set; }
        public RaffleCustomerNumberBLL() : base(new RaffleCustomerNumberDAO())
        {
            data = new RaffleCustomerNumberDAO();
        }
    }
}