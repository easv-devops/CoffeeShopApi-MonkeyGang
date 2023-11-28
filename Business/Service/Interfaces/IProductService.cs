using Models;
using Models.DTOs;

namespace Service;

public interface IProductService
{
    ProductDto GetProductById(Guid id);
    List<ProductDto> GetAllProducts();
    void AddProduct(ProductDto productDto);
    void UpdateProduct(ProductDto productDto);
    void DeleteProduct(Guid id);
}