using CustomService.Model;
using Sitecore.Services.Core.Data;
using Sitecore.Services.Infrastructure.OData;

namespace CustomService.Controllers
{
    public class TodoListController 
        : ServiceBaseODataController<Todo>
    {
        public TodoListController(IReadOnlyEntityRepository<Todo> repository) 
            : base(repository)
        {
        }
    }
}