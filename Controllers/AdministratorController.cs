using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers
{
    public class AdministratorController : BaseController<Administrator, AdministratorModelFilter, long>
    {
        public new AdministratorBLL business { get; set; }
        public AdministratorController() : base(new AdministratorBLL())
        {
            business = new AdministratorBLL();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<Administrator> Login(string email, string password)
        {
            Administrator administrator = business.GetByEmailAndPassword(email, password);
            if (administrator is null)
                return new NotFoundObjectResult(new { status = 204 });

            string token = TokenService.GenerateTokenAdministrator(administrator);
            return new OkObjectResult(new { token });
        }
    }
}