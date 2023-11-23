using Models;

namespace Data.Repository;

public interface IProductRepository
{
    Product GetProductById(Guid productId);
    IEnumerable<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Guid productId);
}