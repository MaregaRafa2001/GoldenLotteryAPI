using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("Raffles")]
    public class Raffle : BaseModel
    {
        [Key]
        public long RaffleId { get; set; }
        public int NumberRange { get; set; }
        public decimal Price { get; set; }
        public required string Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? LargeDescription { get; set; }
        public Enums.ERaffleStatus RaffleStatusId { get; set; }
        public DateTime LotteryDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}