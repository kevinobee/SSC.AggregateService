using CustomService.Model;
using Sitecore.Services.Core.OData;
using Sitecore.Services.Core.OData.Edm;
using Sitecore.Services.Infrastructure.OData.Edm;

namespace CustomService.OData
{
    public class AdminServiceDescriptor : AggregateDescriptor
    {
        public AdminServiceDescriptor() 
            : base(
                "Admin Services", 
                "admin", 
                new DefaultEdmModelBuilder(new[]
                {
                    new EntitySetDefintion(typeof(Todo), "TodoList") // Use the collectionName parameter to prevent pluralization of the EntitySet name in the EDM
                }))
        {
        }
    }
}