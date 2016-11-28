using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomService.Model;
using Sitecore.Services.Core.Data;

namespace CustomService.Data
{
    public class TodoRepository : IReadOnlyEntityRepository<Todo>
    {
        private static readonly IList<Todo> TodoList = new[] {new Todo(), new Todo(), new Todo(), new Todo()};

        async Task<Todo> IReadOnlyEntityRepository<Todo>.GetById(string id)
        {
            return await Task.Run(() => TodoList.FirstOrDefault(todoItem => todoItem.Id == id));
        }

        async Task<IQueryable<Todo>> IReadOnlyEntityRepository<Todo>.GetData()
        {
            return await Task.Run(() => TodoList.OrderBy(todoItem => todoItem.Index).AsQueryable());
        }
    }
}