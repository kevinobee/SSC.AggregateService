using System;
using System.IO;
using Microsoft.OData.Edm;
using Sitecore.Services.Core.OData.Edm;

namespace CustomService.OData.Edm
{
    internal class CsdlEdmModelBuilder : IEdmModelBuilder
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly string _csdlFilePath;

        public CsdlEdmModelBuilder(string csdlFilePath)
        {
            if (csdlFilePath == null)
            {
                throw new ArgumentNullException("csdlFilePath");
            }

            if (!File.Exists(csdlFilePath))
            {
                throw new ArgumentException(string.Format("File does not exist ({0})", csdlFilePath));
            }

            _csdlFilePath = csdlFilePath;
        }

        public IEdmModel GetEdmModel()
        {
            throw new NotImplementedException(
                        "Use _csdlFilePath to parse input file to generate EDM");
        }
    }
}