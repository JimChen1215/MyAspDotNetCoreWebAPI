
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace WebAPIDemo.Filter
{
    //Package:  Microsoft.AspNetCore.Mvc.Core (v2.2.5) is needed for this action
    public class LogAttribute : ActionFilterAttribute
    {
       
        public LogAttribute()
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {            
            Debug.WriteLine(string.Format("-- before --Action Method {0} executing at {1}"
                , actionContext.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {           
            Debug.WriteLine(string.Format("** after **Action Method {0} executed at {1}"
                , actionExecutedContext.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }
    }
}
