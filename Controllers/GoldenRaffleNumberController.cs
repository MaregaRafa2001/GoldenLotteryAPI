using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class GoldenRaffleNumberController : BaseController<GoldenRaffleNumber, GoldenRaffleNumberModelFilter, long>
    {
        public new GoldenRaffleNumberBLL business { get; set; }
        public GoldenRaffleNumberController() : base(new GoldenRaffleNumberBLL())
        {
            business = new GoldenRaffleNumberBLL();
        }
    }
}
