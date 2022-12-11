using BO;
using BlApi;

namespace BlApi;

public interface IProduct
{
    /// <summary>
    /// Returns list of all products, for manager and buyer
    /// </summary>
    /// <returns> List of products </returns>
    public IEnumerable<ProductForList> GetAll();
    /// <summary>
    /// Get product item, for manager
    /// </summary>
    /// <param name="ID"></param>
    /// <returns> Product </returns>
    public Product Get(int ID);
    /// <summary>
    /// Get product item, for buyer screen
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="cart"></param>
    /// <returns> ProductItem </returns>
    public ProductItem Get(int ID, Cart cart);
    /// <summary>
    /// Add product to the store, for manager
    /// </summary>
    /// <param name="product"></param>
    public void Add(Product product);
    /// <summary>
    /// Delete product from the store, for manager
    /// </summary>
    /// <param name="ID"></param>
    public void Delete(int ID);
    /// <summary>
    /// Update existing product in the store, for manager
    /// </summary>
    /// <param name="product"></param>
    public void Update(Product product);
}