using GoldenLotteryAPI.ModelFilters.Core;
using System.ComponentModel.DataAnnotations;

namespace GoldenLotteryAPI
{
    public class CustomerAddressModelFilter : BaseModelFilter
    {
        [Key]
        public long? CustomerAddressId { get; set; }
        public long? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? ZipCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? District { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }
    }
}