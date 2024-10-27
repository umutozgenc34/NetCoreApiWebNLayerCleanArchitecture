

using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Products;
using System.Net;

namespace Services.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{

    public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
    {
        var products = await productRepository.GetAll().ToListAsync();
        var productAsDto = products.Select(x => new ProductDto(x.Id, x.Name, x.Price, x.Stock)).ToList();
        return  ServiceResult<List<ProductDto>>.Success(productAsDto);
        
    }

    public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        // 1-10 => ilk 10 kayıt Skip(0).Take(10)
        // 2-10 => 11- 20 kayıt Skip(10).Take(10)
        // 3-10 => 21-30 kayıt Skip (20).Take(10)

        var products = await productRepository.GetAll().Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();  
        var productAsDto = products.Select(x => new ProductDto (x.Id,x.Name,x.Price,x.Stock)).ToList();
        return ServiceResult<List<ProductDto>>.Success(productAsDto);
    }

    public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count)
    {
        var products = await productRepository.GetTopPriceProductAsync(count);

        var productAsDto = products.Select(x => new ProductDto(x.Id, x.Name, x.Price, x.Stock)).ToList();

        return new ServiceResult<List<ProductDto>>()
        {
            Data = productAsDto
        };
    }

    public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            ServiceResult<ProductDto>.Fail("Product not found " ,HttpStatusCode.NotFound);
        }

        var productAsDto = new ProductDto(product!.Id,product.Name, product.Price, product.Stock);

        return ServiceResult<ProductDto>.Success(productAsDto)!;
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
    {
        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),
            $"api/products/{product.Id}");
    }

    public async Task<ServiceResult> UpdateAsync (int id,UpdateProductRequest request)
    {
        //Fast fail
        //Guard Clauses

        var product = await productRepository.GetByIdAsync(id);

        if(product is null)
        {
            return ServiceResult.Fail("Product Not Found",HttpStatusCode.NotFound);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);

    }

    public async Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
        {
            return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
        }

        product.Stock = request.Quantity;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    
}
