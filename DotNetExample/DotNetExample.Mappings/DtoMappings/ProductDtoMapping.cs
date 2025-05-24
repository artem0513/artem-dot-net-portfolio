using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.DtoMappings
{
    internal class ProductDtoMapping : Profile
    {
        public ProductDtoMapping()
        {
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}
