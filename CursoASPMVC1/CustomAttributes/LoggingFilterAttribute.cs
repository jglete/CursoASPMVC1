using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace CursoASPMVC1.CustomAttributes
{
    public class LoggingFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("(Logging Filter)Action Executing: " + filterContext.ActionDescriptor.ActionName);

            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
                System.Diagnostics.Debug.WriteLine("(Logging Filter)Exception thrown");

            base.OnActionExecuted(filterContext);
        }
    }
}

