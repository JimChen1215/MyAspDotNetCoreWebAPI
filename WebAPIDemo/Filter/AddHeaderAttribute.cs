using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Filter
{
    //This is a built-in attribute filters
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name, new string[] { _value });
            base.OnResultExecuting(context);
            Debug.WriteLine(string.Format("-- before --Action Method {0} executing at {1}"
               , context.ActionDescriptor.DisplayName, DateTime.Now.ToShortDateString()), "Web API AddHeaderAttribute");
        }
    }
}
