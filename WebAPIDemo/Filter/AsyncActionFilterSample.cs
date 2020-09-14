
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAPIDemo.Filter
{
    /****
        Two ways to make this annotation working:
        1. extends from Attribute and implement IActionFilter or extends from ActionFilterAttribute
            Then add [Log] at level of class
                AsyncActionFilterSample : Attribute, IAsyncActionFilter
        2. only implement IActionFilter, register this action filter in the ConfigureService in  Startup.cs class:
                services.AddScoped<AsyncActionFilterSample>();
            Then use annotation: [ServiceFilter(typeof(AsyncActionFilterSample))]
    */
    public class AsyncActionFilterSample : Attribute, IAsyncActionFilter
    {
        private ILogger _logger;
        public AsyncActionFilterSample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AsyncActionFilterSample>();
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            // execute any code before the action executes
            Debug.WriteLine(string.Format("-- before --Action Method {0} executing at {1}"
               , actionContext.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "AsyncActionFilterExample");
            _logger.LogInformation("--- Adding logging examples in Filter, before execution ---");

            //execute the action
            var result = await next();
            // execute any code after the action executes
            Debug.WriteLine(string.Format("** after **Action Method {0} executed at {1}"
                , actionContext.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "AsyncActionFilterExample");

            _logger.LogInformation("***  Adding logging examples in Filter, after execution ***");
        }
    }
}
