using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("WinningRaffleNumbers")]
    public class WinningRaffleNumber : BaseModel
    {
        [Key]
        public long WinningRaffleNumberId { get; set; }
        public long RaffleId { get; set; }
        public int Number { get; set; }
    }
}
