using CustomService.Data;
using CustomService.Model;
using CustomService.OData;

namespace CustomService.Controllers
{
    public class TodoController 
        : ODataControllerBase<Todo>
    {
        public TodoController(IReadWriteEntityRepository<Todo> repository) 
            : base(repository)
        {
        }
    }
}