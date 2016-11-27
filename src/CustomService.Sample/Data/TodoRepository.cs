using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomService.Model;

namespace CustomService.Data
{
    public class TodoRepository : IReadWriteEntityRepository<Todo>
    {
        private static List<Todo> _todoList = new List<Todo>();


        public Task Add(Todo entity)
        {
            if (!entity.HasIdentity())
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            return Task.Run(() => _todoList.Add(entity));
        }

        public Task Delete(Todo entity)
        {
            return Task.Run(() => _todoList = _todoList.Where(todoItem => todoItem.Id != entity.Id).ToList());
        }

        public Task<Todo> GetById(string id)
        {
            return Task.Run(() => _todoList.FirstOrDefault(todoItem => todoItem.Id == id));
        }

        public async Task<IQueryable<Todo>> GetData()
        {
            return await Task.Run(() => _todoList.OrderBy(todoItem => todoItem.Index).AsQueryable());
        }

        public Task Update(Todo entity)
        {
            return Task.Run(() =>
            {
                _todoList = _todoList.Where(todoItem => todoItem.Id != entity.Id).ToList();
                _todoList.Add(entity);
            });
        }

        public async Task<bool> Exists(string identity)
        {
            return await Task.Run(() => _todoList.Any(x => x.Id == identity));
        }
    }
}