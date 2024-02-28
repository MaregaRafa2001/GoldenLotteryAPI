using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class WinningRaffleNumberController : BaseController<WinningRaffleNumber, WinningRaffleNumberModelFilter, long>
    {
        public new WinningRaffleNumberBLL business { get; set; }
        public WinningRaffleNumberController() : base(new WinningRaffleNumberBLL())
        {
            business = new WinningRaffleNumberBLL();
        }
    }
}
