

using FluentValidation;
using Repositories.Products;

namespace Services.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    private readonly IProductRepository _productRepository;
    public CreateProductRequestValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ürün ismi gereklidir")
            .Length(3, 25).WithMessage("Ürün ismi 3 ile 25 karakter arasında olmalıdır");
            //.Must(MustUniqueProductName).WithMessage("Ürün ismi veritabanında bulunmaktadır");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Ürünün fiyatı 0 dan büyük olmalıdır");

        RuleFor(x => x.Stock)
            .InclusiveBetween(1, 100).WithMessage("Stok adedi 1 ile 100 arasında olmalıdır");
    }

   

    //1. Yol sync validation
    //private bool MustUniqueProductName(string name)
    //{
    //    //false bir hata var
    //    // true bir hata yok
    //    return _productRepository.Where(x=> x.Name==name).Any();
    //}
}
