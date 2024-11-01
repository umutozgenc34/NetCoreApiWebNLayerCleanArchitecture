﻿using Services.Products;

namespace Services.Categories.Dtos;

public record CategoryWithProductsDto(int Id, string Name, List<ProductDto> Products);


