﻿using App.Application.Features.Categories.Create;
using App.Application.Features.Categories.Dtos;
using App.Application.Features.Categories.Update;

namespace App.Application.Features.Categories;

public interface ICategoryService
{
    Task<ServiceResult<List<CategoryDto>>> GetAllAsync();
    Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int categoryId);
    Task<ServiceResult<List<CategoryWithProductsDto>>> GetCategoryWithProductsAsync();
    Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);
    Task<ServiceResult> DeleteAsync(int id);

}
