using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class AdministratorModelFilter : BaseModelFilter
    {
        [Key]
        public long? AdministratorId { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
