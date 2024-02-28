using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.Models
{
    public class City : BaseModel
    {
        public long CityId { get; set; }
        public int StateId { get; set; }
        public required string Name { get; set; }
    }
}
