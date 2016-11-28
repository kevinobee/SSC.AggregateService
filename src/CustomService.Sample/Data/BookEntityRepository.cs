using System.Linq;

using CustomService.Model;

using Sitecore.Services.Core;

namespace CustomService.Data
{
    public class BookEntityRepository : IRepository<BookEntity>
    {
        public IQueryable<BookEntity> GetAll()
        {
            return (new BookEntity[] { }).AsQueryable();
        }

        public BookEntity FindById(string id)
        {
            return new BookEntity();
        }

        public void Add(BookEntity entity)
        {            
        }

        public bool Exists(BookEntity entity)
        {
            return false;
        }

        public void Update(BookEntity entity)
        {
        }

        public void Delete(BookEntity entity)
        {
        }
    }
}