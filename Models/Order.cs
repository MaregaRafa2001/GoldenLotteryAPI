using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("Orders")]
    public class Order : BaseModel
    {
        [Key]
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public long RaffleId { get; set; }
        public decimal Price { get; set; }
        public Enums.EOrderStatus OrderStatusId { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}
