using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class RaffleBLL : BaseBusinessObject<Raffle, RaffleModelFilter, long>
    {
        public new RaffleDAO data {  get; set; }
        public RaffleBLL() : base(new RaffleDAO())
        {
            data = new RaffleDAO();
        }
    }
}