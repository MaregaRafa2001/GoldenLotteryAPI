using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class GoldenRaffleNumberBLL : BaseBusinessObject<GoldenRaffleNumber, GoldenRaffleNumberModelFilter, long>
    {
        public new GoldenRaffleNumberDAO data { get; set; }
        public GoldenRaffleNumberBLL() : base(new GoldenRaffleNumberDAO())
        {
            data = new GoldenRaffleNumberDAO();
        }
    }
}