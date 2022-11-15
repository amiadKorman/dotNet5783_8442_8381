using DO;
using static Dal.DataSource;
using System.Linq;
using System;

namespace Dal;

public class DalProduct
{
    #region ADD
    /// <summary>
    /// Add new product item
    /// </summary>
    /// <param name="product"></param>
    /// <returns>ID of new product</returns>
    /// <exception cref="Exception"></exception>
    public int AddProduct(Product product)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == product.ID);
        if (index == -1)
            throw new Exception("Product ID Already Exist");
        productsArray[Config.productsLastIndex++] = new()
        {
            ID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            InStock = product.InStock
        };
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
    public Product GetProduct(int productID)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == productID);
        if (index == -1)
            throw new Exception("Product ID Not Exist");

        return productsArray[index];
    }
    
    /// <summary>
    /// Return all the products in the DataSource
    /// </summary>
    /// <returns>products array</returns>
    public Product[] GetAllProdoct()
    {
        Product[] products = new Product[Config.productsLastIndex];
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
    public void UpdateProduct(Product newProduct)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == newProduct.ID);
        if (index == -1)
            throw new Exception("Product ID Not Exist");

        productsArray[index] = newProduct;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete product item by given ID
    /// </summary>
    /// <param name="productID"></param>
    /// <exception cref="Exception"></exception>
    public void DeleteProduct(int productID)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == productID);
        if (index == -1)
            throw new Exception("Product ID Not Exist");

        productsArray = productsArray.Where((e, i) => i != index).ToArray();
        Config.productsLastIndex--;
    }
    #endregion
}
