using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers.Core
{
    [Route("[controller]")]
    [Authorize(Policy = nameof(Enums.EUserPolicies.Administrator))]
    public class BaseController<T, F, I>(IBusinessObject<T, F, I> b) : ControllerBase, IController<T, F, I> where T : IModel where F : IModelFilter
    {
        public IBusinessObject<T, F, I> business { get; set; } = b;

        [HttpPost]
        [Route("")]
        public virtual ActionResult<T> Insert([FromBody] T model)
        {
            business.Insert(model);
            return model;
        }

        [HttpPut]
        [Route("")]
        public virtual ActionResult<T> Update([FromBody] T model)
        {
            business.Update(model);
            return model;
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual void Delete(I id)
        {
            business.Delete(id);
        }

        [HttpGet]
        [Route("")]
        public virtual ActionResult<List<T>> ListByFilter(F filter)
        {
            return business.ListByFilter(filter);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual ActionResult<T> GetById(I id)
        {
            return business.GetById(id);
        }
    }
}
