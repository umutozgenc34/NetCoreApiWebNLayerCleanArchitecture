using Repositories.Products;

namespace Services.Products;

public interface IProductService
{
    public Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count);
}
