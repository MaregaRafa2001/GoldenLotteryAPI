using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers
{
    public class RaffleCustomerController : BaseController<RaffleCustomer, RaffleCustomerModelFilter, long>
    {
        public new RaffleCustomerBLL business { get; set; }
        public RaffleCustomerController() : base(new RaffleCustomerBLL())
        {
            business = new RaffleCustomerBLL();
        }
    }
}
