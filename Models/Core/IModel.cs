namespace GoldenLotteryAPI.Models.Core
{
    public interface IModel
    {
        public DateTimeOffset DateInserted { get; set; }
        public long InsertedBy { get; set; }
    }
}
