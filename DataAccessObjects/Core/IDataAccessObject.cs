using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.DataAccessObjects.Core
{
    public interface IDataAccessObject<T, F, I> where T : IModel where F : IModelFilter
    {
        void Insert(T model);
        void Update(T model);
        void Delete(I id);
        List<T> ListByFilter(F filter);
        T GetById(I filter);
    }
}
