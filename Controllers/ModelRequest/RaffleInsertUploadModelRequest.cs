using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.Controllers.ModelRequest
{
    public class RaffleInsertFileModelRequest
    {
        public required IFormFile File { get; set; }
        public required Raffle Raffle { get; set; }
    }
}
