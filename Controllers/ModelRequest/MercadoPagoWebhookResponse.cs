using Newtonsoft.Json;

namespace GoldenLotteryAPI.Controllers.ModelRequest
{
    public class MercadoPagoWebhookResponse
    {
        public string action { get; set; }
        public string? api_version { get; set; }
        public string? date_created { get; set; }
        public object? id { get; set; }
        public object? data { get; set; }
        public bool? live_mode { get; set; }
        public string? type { get; set; }
        public string? user_id { get; set; }
    }

    public class MercadoPagoWebhookData
    {
        public object? id { get; set; }
    }
}
