using AutoMapper;
using Lead.Models.Models;
using Lead.Models.Entities;

namespace Lead.WebAPI
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Register mappings between models
        /// All mapping should be added here and are only initilised once
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VisitorModel, Visitor>().ReverseMap();
                cfg.CreateMap<OrderModel, Order>().ReverseMap();
            });
        }
    }
}