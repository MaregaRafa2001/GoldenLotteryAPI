using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GoldenLotteryAPI.Models
{
    [Table("GoldenRaffleNumbers")]
    public class GoldenRaffleNumber : BaseModel
    {
        [Key]
        public long GoldenRaffleNumberId { get; set; }
        public long RaffleId { get; set; }
        public int Number { get; set; }
        public DateTime LotteryDate { get; set; }
        public Enums.EGoldenRaffleNumberStatus GoldenRaffleNumberStatusId { get; set; }
    }
}
