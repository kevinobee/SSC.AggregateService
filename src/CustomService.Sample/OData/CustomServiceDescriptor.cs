using CustomService.OData.Edm;
using Sitecore.Services.Core.OData;
using Sitecore.Services.Core.OData.Edm;

namespace CustomService.OData
{
    public class CustomServiceDescriptor : AggregateDescriptor
    {
        public CustomServiceDescriptor(IEdmModelBuilder modelBuilder)
            : base(
                "CustomRoute",
                "custom",
                modelBuilder)
        {
        }

        public CustomServiceDescriptor()
            // Code Smell (new is glue).... Poor Man's DI
            : this(new CustomServiceEdmBuilder())
        {   
        }
    }
}