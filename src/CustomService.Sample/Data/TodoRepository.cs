using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomService.Model;
using Sitecore.Services.Core.Data;

namespace CustomService.Data
{
    public sealed class TodoRepository : IReadWriteEntityRepository<Todo>
    {
        private static readonly IList<Todo> TodoList = new[] { new Todo(), new Todo(), new Todo(), new Todo() };

        async Task<Todo> IReadOnlyEntityRepository<Todo>.GetById(string id)
        {
            return await Task.Run(() => TodoList.FirstOrDefault(todoItem => todoItem.Id == id));
        }

        async Task<IQueryable<Todo>> IReadOnlyEntityRepository<Todo>.GetData()
        {
            return await Task.Run(() => TodoList.OrderBy(todoItem => todoItem.Index).AsQueryable());
        }

        public async Task Add(Todo entity)
        {
            if (TodoList.Contains(entity)) throw new ArgumentException(string.Format("Entity exists (Id: {0})", entity.Id));

            await Task.Run(() => TodoList.Add(entity));
        }

        public async Task Delete(Todo entity)
        {
            if (!entity.HasIdentity()) throw new ArgumentException("Id missing");

            if (!await Exists(entity.Id)) throw new ArgumentException(string.Format("Entity not found (Id: {0})", entity.Id));

            await Task.Run(() => TodoList.Remove(entity));
        }

        public async Task Update(Todo entity)
        {
            if (!entity.HasIdentity()) throw new ArgumentException("Id missing");

            if (! await Exists(entity.Id)) throw new ArgumentException(string.Format("Entity not found (Id: {0})", entity.Id));

            await Task.Run(() =>
            {
                var staleEntityIndex = TodoList.IndexOf(TodoList.Single(x => x.Id == entity.Id));

                TodoList[staleEntityIndex] = entity;
            });
        }

        public async Task<bool> Exists(string identity)
        {
            return await Task.Run(() => TodoList.Any(x => x.Id == identity));
        }
    }
}