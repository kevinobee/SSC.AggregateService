using System.Web.OData.Builder;
using CustomService.Model;
using Microsoft.OData.Edm;
using Sitecore.Services.Core.OData.Edm;

namespace CustomService.OData.Edm
{
    public class CustomServiceEdmBuilder : IEdmModelBuilder
    {
        public IEdmModel GetEdmModel()
        {
            var builder = 
                new ODataConventionModelBuilder
                {
                    Namespace = typeof(Customer).Namespace
                };

            // Nicer syntax...
            //
            //_modelBuilder
            //    .AddEntitySet<Customer>()
            //    .AddEntitySet<Order>()
            //    ;

            foreach (var modelType in new [] { typeof(Customer), typeof(Order) })
            {
                var entityType = builder.AddEntityType(modelType);
                builder.AddEntitySet(string.Format("{0}s", modelType.Name), entityType);
            }

            // Add TopBuyer Function to the Customer collection

            builder
                 .EntityType<Customer>()
                .Collection
                .Function("TopBuyer")
                .ReturnsFromEntitySet<Customer>("Customers");

            return builder.GetEdmModel();
        }
    }
}