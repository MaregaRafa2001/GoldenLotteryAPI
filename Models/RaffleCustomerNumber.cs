using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("RaffleCustomerNumberId")]
    public class RaffleCustomerNumber : BaseModel
    {
        [Key]
        public long RaffleCustomerNumberId { get; set; }
        public long RaffleCustomerId { get; set; }
        public int Number { get; set; }
    }
}
