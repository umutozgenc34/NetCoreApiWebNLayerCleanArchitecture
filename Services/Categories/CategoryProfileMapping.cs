

using AutoMapper;
using Repositories.Categories;
using Repositories.Products;
using Services.Categories.Create;
using Services.Categories.Dtos;
using Services.Categories.Update;
using Services.Products.Create;
using Services.Products.Update;

namespace Services.Categories;

public class CategoryProfileMapping : Profile
{
    public CategoryProfileMapping()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Category,CategoryWithProductsDto>().ReverseMap();
        CreateMap<CreateCategoryRequest, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        CreateMap<UpdateCategoryRequest, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        
    }
}
