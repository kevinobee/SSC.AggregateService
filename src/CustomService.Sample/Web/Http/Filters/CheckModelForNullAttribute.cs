using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CustomService.Web.Http.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsValue(null))
            {
                actionContext.Response = 
                    actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        string.Format(
                            "The argument cannot be null: {0}",
                            string.Join(",", actionContext.ActionArguments
                                .Where(i => i.Value == null)
                                .Select(i => i.Key))));
            }
        }
    }
}