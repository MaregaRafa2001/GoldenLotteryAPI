using GoldenLotteryAPI.DataAccessObjects.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.BusinessObjects.Core
{
    public class BaseBusinessObject<T, F, I>(IDataAccessObject<T, F, I> data) : IBusinessObject<T, F, I> where T : IModel where F : IModelFilter
    {
        public IDataAccessObject<T, F, I> data { get; set; } = data;

        public virtual void Insert(T model)
        {
            data.Insert(model);
        }

        public virtual void Update(T model)
        {
            data.Update(model);
        }

        public virtual void Delete(I id)
        {
            data.Delete(id);
        }

        public virtual List<T> ListByFilter(F filter)
        {
            return data.ListByFilter(filter);
        }

        public virtual T GetById(I model)
        {
            return data.GetById(model);
        }
    }
}
