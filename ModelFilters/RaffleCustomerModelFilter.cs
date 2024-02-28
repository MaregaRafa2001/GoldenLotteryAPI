using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class RaffleCustomerModelFilter : BaseModelFilter
    {
        [Key]
        public long? RaffleCustomerId { get; set; }
        public long? RaffleId { get; set; }
        public long? CustomerId { get; set; }
        public Enums.ERaffleCustomerStatus? RaffleCustomerStatusId { get; set; }

        public string? CustomerName { get; set; }
    }
}