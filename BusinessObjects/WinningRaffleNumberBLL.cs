using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class WinningRaffleNumberBLL : BaseBusinessObject<WinningRaffleNumber, WinningRaffleNumberModelFilter, long>
    {
        public new WinningRaffleNumberDAO data { get; set; }
        public WinningRaffleNumberBLL() : base(new WinningRaffleNumberDAO())
        {
            data = new WinningRaffleNumberDAO();
        }
    }
}