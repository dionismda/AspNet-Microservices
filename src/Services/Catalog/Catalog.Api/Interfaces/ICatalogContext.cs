namespace Catalog.Api.Interfaces;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}
