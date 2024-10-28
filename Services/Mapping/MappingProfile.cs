

using AutoMapper;
using Repositories.Products;
using Services.Products;
using Services.Products.Create;
using Services.Products.Update;

namespace Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Product>().ForMember(des=> des.Name,
            opt=> opt.MapFrom(src=>src.Name.ToLowerInvariant()));
        CreateMap<UpdateProductRequest, Product>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}
