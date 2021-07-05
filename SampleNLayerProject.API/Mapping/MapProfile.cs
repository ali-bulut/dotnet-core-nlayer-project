using System;
using AutoMapper;
using SampleNLayerProject.API.DTOs;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // when an object is type of category, then convert it to CategoryDto. (for example; get operations)
            CreateMap<Category, CategoryDto>();
            // when an object is type of CategoryDto(generally coming from client),
            // then convert it to Category. (for example; post/put/patch operations) 
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}
