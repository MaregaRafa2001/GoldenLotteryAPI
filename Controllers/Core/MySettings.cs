namespace GoldenLotteryAPI.Controllers.Core
{
    public static class GlobalSettings
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Initialize(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string BaseURL()
        {
            if (_httpContextAccessor == null)
            {
                throw new InvalidOperationException("Settings not initialized. Call Initialize method first.");
            }

            var request = _httpContextAccessor.HttpContext.Request;
            return $"{request.Scheme}://{request.Host}";
        }

    }
}