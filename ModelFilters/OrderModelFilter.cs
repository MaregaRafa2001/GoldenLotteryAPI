using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class OrderModelFilter : BaseModelFilter
    {
        [Key]
        public long? OrderId { get; set; }
        public long? CustomerId { get; set; }
        public long? RaffleId { get; set; }
        public decimal? Price { get; set; }
        public Enums.EOrderStatus? OrderStatusId { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}