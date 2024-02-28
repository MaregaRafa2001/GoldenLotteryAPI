using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("Customers")]
    public class Customer : BaseModel
    {
        [Key]
        public long CustomerId { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
