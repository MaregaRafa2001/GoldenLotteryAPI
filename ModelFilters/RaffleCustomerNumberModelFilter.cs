using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class RaffleCustomerNumberModelFilter : BaseModelFilter
    {
        [Key]
        public long? RaffleCustomerNumberId { get; set; }
        public long? RaffleCustomerId { get; set; }
        public int? Number { get; set; }
    }
}