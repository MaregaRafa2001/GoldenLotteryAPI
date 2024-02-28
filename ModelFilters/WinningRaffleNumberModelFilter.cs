using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class WinningRaffleNumberModelFilter : BaseModelFilter
    {
        [Key]
        public long? WinningRaffleNumberId { get; set; }
        public long? RaffleId { get; set; }
        public int? Number { get; set; }
    }
}