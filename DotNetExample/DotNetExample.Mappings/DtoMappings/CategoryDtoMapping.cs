using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.DtoMappings
{
    internal class CategoryDtoMapping : Profile
    {
        public CategoryDtoMapping()
        {
            CreateMap<CategoryEntity, CategoryDto>();
        }
    }
}
