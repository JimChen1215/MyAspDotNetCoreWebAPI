using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Filter
{
    //In the controller, you choose TypeFilter or ServiceFilter in the annotation
    #region snippet_TypeFilter_Implementation
    public class LogConstantFilter : IActionFilter
    {
        private readonly string _value;
        private readonly ILogger<LogConstantFilter> _logger;

        public LogConstantFilter(string value, ILogger<LogConstantFilter> logger)
        {
            _logger = logger;
            _value = value;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(_value);
            Debug.WriteLine(string.Format("-- before --Action Method {0} executing at {1}"
               , context.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "Web API LogConstant");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { 
        }
    }
    #endregion
}
