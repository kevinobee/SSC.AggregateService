using CustomService.Model;

using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace CustomService.Controllers
{
    public class BookEntityServicesController : EntityService<BookEntity>
    {
        public BookEntityServicesController(IRepository<BookEntity> repository)
            : base(repository)
        {
        }
    }
}