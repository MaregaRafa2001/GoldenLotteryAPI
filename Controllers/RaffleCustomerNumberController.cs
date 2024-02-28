using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class RaffleCustomerNumberController : BaseController<RaffleCustomerNumber, RaffleCustomerNumberModelFilter, long>
    {
        public new RaffleCustomerNumberBLL business { get; set; }
        public RaffleCustomerNumberController() : base(new RaffleCustomerNumberBLL())
        {
            business = new RaffleCustomerNumberBLL();
        }
    }
}
