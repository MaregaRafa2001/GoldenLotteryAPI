using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers.ModelRequest
{
    public class OrderCreatePaymentModelRequest
    {
        public long CustomerId { get; set; }
        public long RaffleId { get; set; }
        public int QuantityNumbers { get; set; }
    }
}
