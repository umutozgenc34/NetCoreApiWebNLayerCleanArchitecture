﻿using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Dtos;
using App.Application.Features.Categories.Update;
using App.Domain.Entities;
using AutoMapper;


namespace App.Application.Features.Categories;

public class CategoryProfileMapping : Profile
{
    public CategoryProfileMapping()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
        CreateMap<CreateCategoryRequest, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        CreateMap<UpdateCategoryRequest, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));


    }
}