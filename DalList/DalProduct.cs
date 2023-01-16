using DO;
using DalApi;

namespace Dal;

internal class DalProduct : IProduct
{
    DataSource ds = DataSource.instance;

    #region ADD
    /// <summary>
    /// Add new product
    /// </summary>
    /// <param name="product"></param>
    /// <returns> product ID </returns>
    /// <exception cref="DalAlreadyExistsException"></exception>
    public int Add(Product product)
    {
        if (ds.products.FirstOrDefault(p => p?.ID == product.ID) != null)
            throw new DalAlreadyExistsException($"Product with ID={product.ID} already exists");
        ds.products.Add(product);
        return product.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return product by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> product </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public Product Get(int id) => ds.products.FirstOrDefault(p => p?.ID == id) ?? throw new DalDoesNotExistException("Product ID doesn't exist");

    /// <summary>
    /// Return product by given filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public Product Get(Func<Product?, bool>? filter) => ds.products.Where(filter ?? throw new NullReferenceException("Filter can not be empty!")).FirstOrDefault() ?? throw new DalDoesNotExistException("Product doesn't exist");


    /// <summary>
    /// Return all ds.products in DataSource by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns> filtered list of ds.products </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter) =>
        (filter == null ?
            ds.products.Select(product => product) :
            ds.products.Where(filter))
        ?? throw new DalDoesNotExistException("Missing ds.products");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Update(Product product)
    {
        int index = ds.products.FindIndex(p => p?.ID == product.ID);
        if (index == -1)
            throw new DalDoesNotExistException($"Product with ID={product.ID} doesn't exists");

        ds.products[index] = product;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete product item by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        if (ds.products.RemoveAll(p => p?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, product ID doesn't exist");
    }
    #endregion
}
