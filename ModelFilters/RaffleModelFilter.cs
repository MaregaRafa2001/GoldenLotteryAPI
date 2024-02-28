using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class RaffleModelFilter : BaseModelFilter
    {
        [Key]
        public long? RaffleId { get; set; }
        public int? NumberRange { get; set; }
        public decimal? Price { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? LargeDescription { get; set; }
        public Enums.ERaffleStatus? RaffleStatusId { get; set; }
        public DateTime? LotteryDate { get; set; }
    }
}
