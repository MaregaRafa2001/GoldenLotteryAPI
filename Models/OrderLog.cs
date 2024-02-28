using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("OrderLogs")]
    public class OrderLog : BaseModel
    {
        [Key]
        public long OrderLogId { get; set; }
        public long OrderId { get; set; }
        public Enums.EOrderLogEventTypes OrderLogEventTypeId { get; set; }
        public string? Description { get; set; }
    }
}
