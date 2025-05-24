using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.EntityMappings
{
    internal class ProductEntityMapping : Profile
    {
        public ProductEntityMapping()
        {
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}
