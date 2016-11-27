using System.Threading.Tasks;
using Sitecore.Services.Core;
using Sitecore.Services.Core.Data;

namespace CustomService.Data
{
    public interface IReadWriteEntityRepository<TModel> 
        : IReadOnlyEntityRepository<TModel> 
        where TModel : class, IEntityIdentity
    {
        Task Add(TModel entity);

        Task Delete(TModel entity);

        Task Update(TModel entity);

        Task<bool> Exists(string identity);
    }
}