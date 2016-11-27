using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.OData;
using CustomService.Data;
using CustomService.Web.Http.Filters;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.OData;

namespace CustomService.OData
{
    public abstract class ODataControllerBase<TModel> 
        : ServiceBaseODataController<TModel> 
        where TModel : class, IEntityIdentity
    {
        internal const string KeyRequired = "key required";

        internal const string IdRequired = "Missing model Id property";

        private readonly IReadWriteEntityRepository<TModel> _repository;

        protected ODataControllerBase(IReadWriteEntityRepository<TModel> repository) 
            : base(repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public async Task<IHttpActionResult> Post([FromBody] TModel entity)
        {
            if (entity.HasIdentity())
            {
                var entityExists = await _repository.Exists(entity.Id);

                if (entityExists)
                {
                    return Conflict();
                }
            }

            await _repository.Add(entity);

            return Created(entity);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {
            return await Task.FromResult(new NotFoundResult(Request));
        }

        [HttpPut]
        [CheckModelForNull]
        [ValidateModelState]
        public async Task<IHttpActionResult> Put([FromODataUri] string key, [FromBody] TModel update)
        {
            if (update.HasIdentity())
            {
                return BadRequest(IdRequired);
            }
            
            if (string.IsNullOrWhiteSpace(key))
            {
                return BadRequest(KeyRequired);
            }

            var entityExists = await _repository.Exists(key);

            if (! entityExists)
            {
                return NotFound();
            }

            /*
             * Dev. Note: Implementation of PUT not supported for creating resources with user defined keys.
             * 
             * PUT can also be used to create a resource in the case where the resource ID is chosen by the client instead of 
             * by the server. In other words, if the PUT is to a URI that contains the value of a non-existent resource ID. 
             * Again, the request body contains a resource representation. Many feel this is convoluted and confusing. 
             * Consequently, this method of creation should be used sparingly, if at all.
             * 
             * Alternatively, use POST to create new resources and provide the client-defined ID in the body 
             * representation, presumably to a URI that doesn't include the ID of the resource
             * 
             * ref: http://www.restapitutorial.com/lessons/httpmethods.html
             * 
             */

            if (key != update.Id)
            {
                return BadRequest();
            }

            await _repository.Update(update);

            return Updated(update);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return BadRequest(KeyRequired);
            }

            var entity = await _repository.GetById(key);

            if (! entity.HasIdentity())
            {
                return NotFound();
            }

            await _repository.Delete(entity);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}