using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class RaffleImageBLL : BaseBusinessObject<RaffleImage, RaffleImageModelFilter, long>
    {
        public new RaffleImageDAO data { get; set; }
        public RaffleImageBLL() : base(new RaffleImageDAO())
        {
            data = new RaffleImageDAO();
        }
    }
}