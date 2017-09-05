using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.OData.Query;
using Lead.Business.Abstract;
using Lead.DAL.Repositories;
using Lead.Models.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lead.Domain.Abstract;
using Lead.Models.Entities;
using System.Web.OData;
using System.Web.OData.Results;

namespace Lead.Business.Logic
{
    public class VisitorLogic : IVisitorLogic
    {
        private readonly IRepository<Visitor> _visitorRepository;

        public VisitorLogic(IRepository<Visitor> visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        /// <summary>
        /// Returns a visitor as querable, projects it to a visitor model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<VisitorModel> OdataGetSingle(Guid id)
        {
            return _visitorRepository.ListQuerable().Where(x => x.Id == id)
                .ProjectTo<VisitorModel>();
        }

          /// <summary>
        /// Creates a new visitor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<VisitorModel> OdataPost(VisitorModel model)
        {
             var created =  await _visitorRepository.AddAsync(Mapper.Map<Visitor>(model));
             return Mapper.Map<VisitorModel>(created);
        }

        /// <summary>
        /// Returns a list of visitors
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
        public IQueryable<VisitorModel> OdataGet(ODataQueryOptions queryOptions)
        {
            var models = _visitorRepository.ListQuerable().ProjectTo<VisitorModel>();

            //Apply the filter to the query in memory and project to a visitor model
            queryOptions.ApplyTo(models);

            return models;
        }

        /// <summary>
        /// Updates a record with the new values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> OdataPut(Guid id, Delta<VisitorModel> delta, ApiController controller)
        {
            var existing = await _visitorRepository.GetAsync(id);

            if (existing == null)
            {
                return new NotFoundResult(controller);
            }

            var existingModel = Mapper.Map<VisitorModel>(existing);
            delta.Put(existingModel);

            var updated =  await _visitorRepository.UpdateAsync(Mapper.Map<Visitor>(existingModel), existing.Id);

            return new UpdatedODataResult<VisitorModel>(Mapper.Map<VisitorModel>(updated), controller);
        }

        /// <summary>
        /// Deletes a visitor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> ODataDelete (Guid id, ApiController controller)
        {
            var model = await _visitorRepository.GetAsync(id);

            if (model == null)
            {
                return new NotFoundResult(controller);
            }

            await _visitorRepository.DeleteAsync(id);

            return new StatusCodeResult(HttpStatusCode.NoContent, controller);
        }


        /// <summary>
        /// Allows update without specifiying all the values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delta"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> OdataPatch(Guid id, Delta<VisitorModel> delta, ApiController controller)
        {
            var existing = await _visitorRepository.GetAsync(id);

            if (existing == null)
            {
                return new NotFoundResult(controller);
            }

            var existingModel = Mapper.Map<VisitorModel>(existing);
            delta.Patch(existingModel);

            var updated = await _visitorRepository.UpdateAsync(Mapper.Map<Visitor>(existingModel), existing.Id);

            return new UpdatedODataResult<VisitorModel>(Mapper.Map<VisitorModel>(updated), controller);
        }
    }
}
