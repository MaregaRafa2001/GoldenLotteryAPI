using GoldenLotteryAPI.BusinessObjects.Core;
using GoldenLotteryAPI.DataAccessObjects;
using GoldenLotteryAPI.Models;

namespace GoldenLotteryAPI.BusinessObjects
{
    public class AdministratorBLL : BaseBusinessObject<Administrator, AdministratorModelFilter, long>
    {
        public new AdministratorDAO data { get; set; }
        public AdministratorBLL() : base(new AdministratorDAO())
        {
            data = new AdministratorDAO();
        }

        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return data.GetByEmailAndPassword(email, password);
        }
    }
}