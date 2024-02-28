using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("RaffleImages")]
    public class RaffleImage : BaseModel
    {
        [Key]
        public long RaffleImageId { get; set; }
        public required string Url { get; set; }
    }
}
