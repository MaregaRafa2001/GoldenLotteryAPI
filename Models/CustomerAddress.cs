using GoldenLotteryAPI.Models.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLotteryAPI.Models
{
    [Table("CustomerAddresses")]
    public class CustomerAddress : BaseModel
    {
        [Key]
        public long CustomerAddressId { get; set; }
        public long CustomerId { get; set; }
        public required string Name { get; set; }
        public required string ZipCode { get; set; }
        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string District { get; set; }
        public long CityId { get; set; }
        public long StateId { get; set; }
    }
}
