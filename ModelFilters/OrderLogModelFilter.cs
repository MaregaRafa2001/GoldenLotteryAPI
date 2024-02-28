using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class OrderLogModelFilter : BaseModelFilter
    {
        [Key]
        public long?  OrderLogId { get; set; }
        public long? OrderId { get; set; }
        public Enums.EOrderLogEventTypes? OrderLogEventTypeId { get; set; }
        public string? Description { get; set; }
    }
}