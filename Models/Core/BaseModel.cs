namespace GoldenLotteryAPI.Models.Core
{
    public class BaseModel : IModel
    {
        public DateTimeOffset DateInserted { get; set; } = DateTimeOffset.UtcNow;
        public long InsertedBy { get; set; }
    }
}
