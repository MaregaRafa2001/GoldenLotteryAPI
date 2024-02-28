using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers.Core
{
    public interface IController<T, F, I> where T : IModel where F : IModelFilter
    {
        IBusinessObject<T, F, I> business { get; set; }
        ActionResult<T> Insert(T model);
        ActionResult<T> Update(T model);
        void Delete(I id);
        ActionResult<List<T>> ListByFilter(F filter);
        ActionResult<T> GetById(I model);
    }
}
