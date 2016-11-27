using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace CustomService.Controllers
{
    public static class ErrorHandlingReporter
    {
        public static IEnumerable<string> GetState(
                                                HttpRequestMessage requestMessage,
                                                HttpConfiguration httpConfiguration)
        {
            yield return "GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = " + httpConfiguration.IncludeErrorDetailPolicy;

            yield return "Request.GetRequestContext().IncludeErrorDetail = " + requestMessage.GetRequestContext().IncludeErrorDetail;

            var configuration = WebConfigurationManager.OpenWebConfiguration("/");

            var section =
                (CustomErrorsSection)configuration.GetSection("system.web/customErrors");

            yield return "system.web/customErrors = " + section.Mode;

            yield return "IExceptionHandler = " + httpConfiguration.Services.GetExceptionHandler().GetType().FullName;

            var loggers = httpConfiguration.Services.GetExceptionLoggers().ToArray();

            if (!loggers.Any())
            {
                yield return "IExceptionLogger = None configured";
            }
            else
            {
                foreach (var logger in loggers)
                {
                    yield return "IExceptionLogger = " + logger.GetType().FullName;
                }
            }
        }
    }
}