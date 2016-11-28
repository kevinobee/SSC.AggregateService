using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using CustomService.Model;

namespace CustomService.Controllers
{
    public class SimpleWepApiController : ApiController
    {
        [Route("api/books")]
        public IEnumerable<Book> GetBooks()
        {
            return new[]
            {
                new Book { Title = "The Book : " + Request.GetDependencyScope().GetType().FullName }
            };
        }

        [Route("api/books/exception")]
        [HttpGet]
        public IEnumerable<Book> ThrowException()
        {
            var state = 
                ErrorHandlingReporter.GetState(
                                        Request,
                                        GlobalConfiguration.Configuration);

            var builder = new StringBuilder();
            foreach (var msg in state)
            {
                builder.AppendLine(msg);
            }

            throw new Exception("intentional exception\n\n" + builder);
        }
    }
}