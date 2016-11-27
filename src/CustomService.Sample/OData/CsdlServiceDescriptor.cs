using CustomService.OData.Edm;

namespace CustomService.OData
{
    public class CsdlServiceDescriptor : Sitecore.Services.Core.OData.AggregateDescriptor
    {
        public CsdlServiceDescriptor(string csdlFilePath)
            : base(
                "CsdlOdataRoute", 
                "csdl", 
                new CsdlEdmModelBuilder(csdlFilePath))
        {   
        }
    }
}