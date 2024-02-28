using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.BusinessObjects.Core
{
    public interface IBusinessObject<T, F, I> where T : IModel where F : IModelFilter
    {
        IDataAccessObject<T, F, I> data { get; set; }
        void Insert(T model);
        void Update(T model);
        void Delete(I id);
        List<T> ListByFilter(F filter);
        T GetById(I id);
    }
}
