using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers
{
    public class CustomerController : BaseController<Customer, CustomerModelFilter, long>
    {
        public new CustomerBLL business { get; set; }
        public CustomerController() : base(new CustomerBLL())
        {
            business = new CustomerBLL();
        }

        [HttpPost]
        [AllowAnonymous]
        public override ActionResult<Customer> Insert([FromBody] Customer model)
        {
            return base.Insert(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<Customer> Login(string email, string password)
        {
            Customer customer = business.GetByEmailAndPassword(email, password);
            if (customer is null)
                return new NotFoundObjectResult(new { status = 204 });

            string token = TokenService.GenerateTokenCustomer(customer);
            return new OkObjectResult(new { token, customer = new { customer.CustomerId, customer.Name } });
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("{id}/orders")]
        //public ActionResult<List<Order>> Orders(long id, [FromQuery] RaffleModelFilter filter)
        //{
        //    return new OrderBLL().ListCustomerByFilter(id, filter.RaffleId.Value);            
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public override ActionResult<Customer> GetById(long id)
        {
            return base.GetById(id);
        }
    }
}