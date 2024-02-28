using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class RaffleImageModelFilter : BaseModelFilter
    {
        [Key]
        public long? RaffleImageId { get; set; }
        public string? Url { get; set; }
    }
}