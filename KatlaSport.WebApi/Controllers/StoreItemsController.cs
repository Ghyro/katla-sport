using KatlaSport.Services.StoreManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/storeItems")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class StoreItemsController : ApiController
    {
        private readonly IStoreItemService _storeItemService;

        public StoreItemsController(IStoreItemService storeItemService)
        {
            _storeItemService = storeItemService ?? throw new ArgumentNullException(nameof(storeItemService));
        }

        [HttpGet]
        [Route("{hiveSectionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns store items.", Type = typeof(StoreItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionStoreItemsAsync(int hiveSectionId)
        {
            var hive = await _storeItemService.GetStoreItemsAsync(hiveSectionId);
            return Ok(hive);
        }
    }
}