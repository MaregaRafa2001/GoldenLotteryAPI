using GoldenLotteryAPI.Core;

namespace GoldenLotteryAPI.Controllers.ModelRequest
{
    public class OrderUpdateStatusModelRequest
    {
        public Enums.EOrderStatus OrderStatusId { get; set; }
        public required string Description { get; set; }
    }
}
