using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoldenLotteryAPI.Core
{
    public class GlobalExceptionFilterController : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.WriteAllText("log.txt", context.Exception.ToString());

            context.Result = context.Exception switch
            {
                RegisterNotFoundException => new ObjectResult(new {  }) { StatusCode = 200 },
                ApplicationException => new ObjectResult(new { error = context.Exception.Message }) { StatusCode = 400 },
                _ => new ObjectResult(new { error = "Internal Server Error" }) { StatusCode = 500 },
            };
                
            // Evita a interferência com outros tratamentos de exceção configurados
            context.ExceptionHandled = true;
        }

    }
}