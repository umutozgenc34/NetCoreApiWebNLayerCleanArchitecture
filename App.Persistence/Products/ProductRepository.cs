﻿using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Products;

public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    public Task<List<Product>> GetTopPriceProductAsync(int count)
    {
        return Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
    }
}
