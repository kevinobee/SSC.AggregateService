using CustomService.Model;

using Sitecore.Services.Core.Data;
using Sitecore.Services.Infrastructure.OData;

namespace CustomService.Controllers
{
    using ReadOnlyOrderRepository = IReadOnlyEntityRepository<Order>;

    public class OrdersController 
        : ServiceBaseODataController<Order>
    {
        public OrdersController(ReadOnlyOrderRepository repository)
            : base(repository)
        {
        }

        /*
         * Your stuff.. including Functions and Actions
         */
    }
}