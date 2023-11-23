using Models;

namespace Data.Repository;

public class ProductRepository : IProductRepository
{
    private List<Product> products = new List<Product>();

    public Product GetProductById(Guid productId)
    {
        return products.FirstOrDefault(p => p.ProductID == productId);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return products;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        // Implementation to update a product in the database
    }

    public void DeleteProduct(Guid productId)
    {
        products.RemoveAll(p => p.ProductID == productId);
    }
}