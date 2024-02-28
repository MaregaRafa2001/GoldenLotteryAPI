using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class CustomerModelFilter : BaseModelFilter
    {
        [Key]
        public long? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}