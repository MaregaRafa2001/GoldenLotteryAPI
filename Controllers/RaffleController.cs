using GoldenLotteryAPI.BusinessObjects;
using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Controllers.ModelRequest;
using GoldenLotteryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GoldenLotteryAPI.Core.Enums;

namespace GoldenLotteryAPI.Controllers
{
    public class RaffleController : BaseController<Raffle, RaffleModelFilter, long>
    {
        public new RaffleBLL business { get; set; }
        public RaffleController() : base(new RaffleBLL())
        {
            business = new RaffleBLL();
        }

        [AllowAnonymous]
        public override ActionResult<Raffle> GetById(long id)
        {
            return base.GetById(id);
        }

        [AllowAnonymous]
        public override ActionResult<List<Raffle>> ListByFilter(RaffleModelFilter filter)
        {
            return base.ListByFilter(filter);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public override ActionResult<Raffle> Insert([FromBody] Raffle model)
        {
            business.Insert(model);
            return model;
        }

        [HttpPost]
        [Route("InsertFile")]
        [AllowAnonymous]
        public ActionResult<Raffle> InsertFile([FromForm] RaffleInsertFileModelRequest model)
        {

            var filePath = $"{GlobalSettings.BaseURL}/Uploads/{model.File.FileName}";
            using (var stream = new FileStream(filePath, FileMode.Create))
                model.File.CopyToAsync(stream);

            model.Raffle.ImageUrl = filePath;
            business.Insert(model.Raffle);
            return model.Raffle;
        }

        [HttpPut]
        [Route("UpdateFile")]
        [AllowAnonymous]
        public ActionResult<Raffle> UpdateFile([FromForm] RaffleInsertFileModelRequest model)
        {

            if (model.File != null)
            {
                var uploadDirectory = "Uploads";  // Nome do diretório de upload
                var fileName = $"{Guid.NewGuid()}.{model.File.ContentType}";
                var filePath = Path.Combine(uploadDirectory, model.File.FileName);
                var localFilePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);


                using var stream = new FileStream(localFilePath, FileMode.Create);
                model.File.CopyToAsync(stream);
                model.Raffle.ImageUrl = Path.Combine(GlobalSettings.BaseURL(), filePath);
            }

            business.Update(model.Raffle);
            return model.Raffle;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Customers")]
        public ActionResult<List<Customer>> ListCustomerByFilter([FromQuery] RaffleCustomerModelFilter filter)
        {
            return new OrderBLL().ListCustomerByFilter(filter);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Status")]
        public ActionResult<List<SelectOption>> ListRaffleStatus()
        {
            return Enum.GetValues(typeof(ERaffleStatus)).Cast<ERaffleStatus>()
                .Select(status => new SelectOption
                {
                    Value = (int)status,
                    Text = status.ToString()
                })
                .ToList();

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("draw/golden")]
        public ActionResult<string> DrawGoldenNumber([FromQuery] int maxValue, [FromBody] GoldenRaffleNumber goldenRaffleNumber)
        {
            GoldenRaffleNumberBLL goldenRaffleNumberBLL = new();
            goldenRaffleNumber.Number = new Random().Next(0, maxValue);
            goldenRaffleNumberBLL.Insert(goldenRaffleNumber);
            return goldenRaffleNumber.Number.ToString();
        }
    }
}