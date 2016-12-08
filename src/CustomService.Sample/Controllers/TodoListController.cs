using CustomService.Model;
using Sitecore.Services.Core.Data;
using Sitecore.Services.Infrastructure.OData;

namespace CustomService.Controllers
{
    public sealed class TodoListController : ODataControllerBase<Todo>
    {
        public TodoListController(IReadWriteEntityRepository<Todo> repository) 
            : base(repository)
        {
        }
    }
}