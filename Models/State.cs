using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.Models
{
    public class State : BaseModel
    {
        public int StateId { get; set; }
        public required string Name { get; set; }
    }
}
