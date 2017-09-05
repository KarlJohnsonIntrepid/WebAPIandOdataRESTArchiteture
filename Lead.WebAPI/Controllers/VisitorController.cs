using Lead.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using Lead.Models.Models;
using Lead.Models.Entities;
using Lead.WebAPI.Controllers.Abstract;

namespace Lead.WebAPI.Controllers
{
    public class VisitorController : BaseApiController
    {
        private readonly IVisitorLogic _visitorLogic;

        public VisitorController(IVisitorLogic visitorLogic)
        {
            _visitorLogic = visitorLogic;
        }

        // GET: odata/visitor(745EF6B9-7642-49F1-9819-14B364650D59)
        [EnableQuery]
        public SingleResult<VisitorModel> Get([FromODataUri] Guid key)
        {
            return SingleResult.Create(_visitorLogic.OdataGetSingle(key));
        }

        // GET: odata/visitor
        // GET  odata/visitor?$skip=2
        [EnableQuery]
        public IQueryable<VisitorModel> Get(ODataQueryOptions<VisitorModel> queryOptions)
        {
            return _visitorLogic.OdataGet(queryOptions);
        }


        // POST: odata/visitor
        //[Authorize()]
        public async Task<IHttpActionResult> Post(VisitorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _visitorLogic.OdataPost(model);

            return Created(created);
        }

        // PUT: odata/visitor(745EF6B9-7642-49F1-9819-14B364650D59)
        //[Authorize()]
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<VisitorModel> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _visitorLogic.OdataPut(key, model, this);
        }

        // PATCH: odata/visitor(745EF6B9-7642-49F1-9819-14B364650D59)
        //[Authorize()]
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<VisitorModel> model)
        {
            //Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _visitorLogic.OdataPatch(key, model, this);
        }


        // DELETE: odata/visitor(745EF6B9-7642-49F1-9819-14B364650D59)
        //[Authorize()]
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            return await _visitorLogic.ODataDelete(key, this);
        }


        // GET /visitor(745EF6B9-7642-49F1-9819-14B364650D59)/Orders
        [EnableQuery]
        public IQueryable<OrderModel> GetOrders([FromODataUri] Guid key)
        {
            //Example loading navigation routes...
            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4

            //Or we can just use $expand=Orders in the Odata query.

            //We would need to add this in the order logic class
            return new List<OrderModel>(){ new OrderModel() { OrderName = "Not Implemented" } }.AsQueryable();
        }

    }
}
