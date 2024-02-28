using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("OrderItems")]
    public class OrderItem : BaseModel
    {
        [Key]
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
    }
}
