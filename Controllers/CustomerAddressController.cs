using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldenLotteryAPI.Controllers
{
    public class CustomerAddressController : BaseController<CustomerAddress, CustomerAddressModelFilter, long>
    {
        public new CustomerAddressBLL business { get; set; }
        public CustomerAddressController() : base(new CustomerAddressBLL())
        {
            business = new CustomerAddressBLL();
        }

        [AllowAnonymous]
        public override ActionResult<List<CustomerAddress>> ListByFilter(CustomerAddressModelFilter filter)
        {
            filter.CustomerId ??= Convert.ToInt64(User.FindFirst("CustomerId")?.Value);
            return base.ListByFilter(filter);
        }

        [Authorize(Policy = nameof(Enums.EUserPolicies.Any))]
        public override ActionResult<CustomerAddress> Insert(CustomerAddress model)
        {
            return base.Insert(model);
        }

        [Authorize(Policy = nameof(Enums.EUserPolicies.Any))]
        public override ActionResult<CustomerAddress> GetById(long id)
        {
            return base.GetById(id);
        }
    }
}