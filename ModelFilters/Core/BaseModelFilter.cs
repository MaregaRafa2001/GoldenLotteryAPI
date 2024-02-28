using GoldenLotteryAPI.Core;

namespace GoldenLotteryAPI.ModelFilters.Core
{
    public class BaseModelFilter : IModelFilter
    {
        private int? _Page { get; set; }
        public int Page
        {
            get
            {
                return _Page ?? 1;
            }
            set
            {
                _Page = value;
            }
        }

        private int? _RecordsPerPage { get; set; }
        public int RecordsPerPage
        {
            get
            {
                return _RecordsPerPage ?? 10;
            }
            set
            {
                _RecordsPerPage = value;
            }
        }

        public DateTimeOffset DateInserted { get; set; }
    }
}
