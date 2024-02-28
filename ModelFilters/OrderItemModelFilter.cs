using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class OrderItemModelFilter : BaseModelFilter
    {
        [Key]
        public long? OrderItemId { get; set; }
        public long? OrderId { get; set; }
        public int? Number { get; set; }
        public decimal? Price { get; set; }
    }
}