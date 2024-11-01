

using Services.Categories.Create;
using Services.Categories.Dtos;
using Services.Categories.Update;

namespace Services.Categories;

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
