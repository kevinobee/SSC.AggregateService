using Sitecore.Services.Core;
using Sitecore.Services.Core.Model;

namespace CustomService.Extensions
{
    public static class EntityIdentityExtensions
    {
        public static bool HasIdentity(this IEntityIdentity entity)
        {
            return !((entity == null) || entity is NullEntity || string.IsNullOrEmpty(entity.Id));
        }
    }
}