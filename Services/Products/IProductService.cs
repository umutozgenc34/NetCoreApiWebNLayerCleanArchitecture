using Repositories.Products;
using Services.Products.Create;
using Services.Products.Update;
using Services.Products.UpdateStock;

namespace Services.Products;

public interface IProductService
{
    public Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count);
    Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
    Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
    Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);


}
