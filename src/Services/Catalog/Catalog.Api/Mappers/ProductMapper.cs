namespace Catalog.Api.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductInputModel, Product>();
        CreateMap<ProductInputModel, ProductViewModel>();
        CreateMap<Product, ProductViewModel>();
    }
}
