using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.EntityMappings
{
    internal class CategoryEntityMapping : Profile
    {
        public CategoryEntityMapping()
        {
            CreateMap<CategoryDto, CategoryEntity>();
        }
    }
}
