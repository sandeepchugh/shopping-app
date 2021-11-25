using ProductApi.Models.Dto;

namespace ProductApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int productId);
    Task<ProductDto> CreateOrUpdateProduct(ProductDto product);
    Task<bool> DeleteProduct(int productId);
}