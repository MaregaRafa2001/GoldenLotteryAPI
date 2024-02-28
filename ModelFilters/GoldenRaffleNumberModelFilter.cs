using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class GoldenRaffleNumberModelFilter : BaseModelFilter
    {
        [Key]
        public long? GoldenRaffleNumberId { get; set; }
        public long? RaffleId { get; set; }
        public int? Number { get; set; }
        public DateTime? LotteryDate { get; set; }
        public Enums.EGoldenRaffleNumberStatus? GoldenRaffleNumberStatusId { get; set; }
    }
}