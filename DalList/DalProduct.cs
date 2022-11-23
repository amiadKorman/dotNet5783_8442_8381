using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalProduct : IProduct
{
    #region ADD
    /// <summary>
    /// Add new product
    /// </summary>
    /// <param name="product"></param>
    /// <returns>product ID</returns>
    /// <exception cref="DalAlreadyExistsException"></exception>
    public int Add(Product product)
    {
        if (products.FirstOrDefault(p => p?.ID == product.ID) != null)
            throw new DalAlreadyExistsException($"Product with ID={product.ID} already exists");
        products.Add(product);
        return product.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return product by given ID
    /// </summary>
    /// <param name="productID"></param>
    /// <returns>product</returns>
    /// <exception cref="Exception"></exception>
    public Product GetById(int id)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == productID);
        if (index == -1)
            throw new Exception("Product ID doesn't exist");

        return productsArray[index];
    }

    /// <summary>
    /// Return all the products in the DataSource
    /// </summary>
    /// <returns>products array</returns>
    public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter)
    {
        Product[] products = new Product[productsLastIndex];
        Array.Copy(productsArray, products, products.Length);
        return products;
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="newProduct"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Product product)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == newProduct.ID);
        if (index == -1)
            throw new Exception("Product ID doesn't exist");

        productsArray[index] = newProduct;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete product item by given ID
    /// </summary>
    /// <param name="productID"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == productID);
        if (index == -1)
            throw new Exception("Product ID doesn't exist");

        productsArray = productsArray.Where((e, i) => i != index).ToArray();
        productsLastIndex--;
    }
    #endregion
}
 