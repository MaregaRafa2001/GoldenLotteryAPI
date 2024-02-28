using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("RaffleCustomers")]
    public class RaffleCustomer : BaseModel
    {
        [Key]
        public long RaffleCustomerId { get; set; }
        public long RaffleId { get; set; }
        public long CustomerId { get; set; }
        public Enums.ERaffleCustomerStatus RaffleCustomerStatusId { get; set; }

        public Customer? Customer { get; set; }
    }
}
