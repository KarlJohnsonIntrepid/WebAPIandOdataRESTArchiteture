using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using Lead.Models.Entities;
using Lead.Models.Models;

namespace Lead.Business.Abstract
{
    public interface IVisitorLogic
    {
        IQueryable<VisitorModel> OdataGetSingle(Guid id);
        IQueryable<VisitorModel> OdataGet(ODataQueryOptions queryOptions);
        Task<VisitorModel> OdataPost(VisitorModel model);
        Task<IHttpActionResult> OdataPut(Guid id, Delta<VisitorModel> model,ApiController controller);
        Task<IHttpActionResult> OdataPatch(Guid id, Delta<VisitorModel> model, ApiController controller);
        Task<IHttpActionResult> ODataDelete(Guid id, ApiController controller);
    }
}
