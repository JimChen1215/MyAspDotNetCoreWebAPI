
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAPIDemo.Filter
{
    //Service filter implementation types are registered in ConfigureServices.
    //  A ServiceFilterAttribute retrieves an instance of the filter from DI.
    public class AddHeaderResultServiceFilter : IResultFilter
    {
        private ILogger _logger;
        private readonly string _value;
        public AddHeaderResultServiceFilter(ILoggerFactory loggerFactory)
        {
            _value = " world";
            _logger = loggerFactory.CreateLogger<AddHeaderResultServiceFilter>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation("--- Header added: {HeaderName}, hello, {_value}", headerName, _value);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has started.
            _logger.LogInformation("*** AddHeaderResultServiceFilter.OnResultExecuted {_value}***", _value);
        }
    }
}
