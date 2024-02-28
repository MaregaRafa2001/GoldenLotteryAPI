using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers
{
    public class RaffleImageController : BaseController<RaffleImage, RaffleImageModelFilter, long>
    {
        public new RaffleImageBLL business { get; set; }
        public RaffleImageController() : base(new RaffleImageBLL())
        {
            business = new RaffleImageBLL();
        }
    }
}
