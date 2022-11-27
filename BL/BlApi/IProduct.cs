using BO;

namespace BlApi;

public interface IProduct
{
    public IEnumerable<ProductForList> GetProducts();
    public Product GetProductById(int id);
    public ProductItem GetProductItem(int id, Cart cart);
    public void Add(Product product);
    public void Delete(Product product);
    public void Update(Product product);
}
