using DO;
using static Dal.DataSource;
using System.Linq;
using System;

namespace Dal;

public class DalProduct
{
    #region Add new product item
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
            throw new Exception("product ID Already Exist");
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

    #region Return product by given ID
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
    #endregion

    #region Return all products
    /// <summary>
    /// Return all the products in the DataSource
    /// </summary>
    /// <returns>products array</returns>
    public Product[] ShowAllProdoct()
    {
        Product[] products = new Product[Config.productsLastIndex];
        Array.Copy(productsArray, products, products.Length);
        return products;
    }

    #endregion

    #region Update product item by given ID
    /// <summary>
    /// Update product item by given ID
    /// </summary>
    /// <param name="newProduct"></param>
    /// <exception cref="Exception"></exception>
    public void UpdateProduct(Product newProduct)
    {
        int index = Array.FindIndex(productsArray, p => p.ID == newProduct.ID);
        if (index == -1)
            throw new Exception("Product ID Not Exist");

        productsArray[index] = newProduct;

        /*for (int i = 0; i < Config.productsLastIndex; i++)
        {
            if (newProduct.ID == productsArray[i].ID)
            {
                if (newProduct.Name != "")
                    productsArray[i].Name = newProduct.Name;
                if (newProduct.Price != 0.0)
                    productsArray[i].Price = newProduct.Price;
                if (newProduct.Category != 0)
                    productsArray[i].Category = newProduct.Category;
                if (newProduct.InStock != 0)
                    productsArray[i].InStock = newProduct.InStock;
                return;
            }
        }

        throw new Exception("Product ID Not Exist");*/
    }
    #endregion

    #region Delete product item by given ID
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
        return;

        /*foreach (var index in from product in productsArray.Where(product => productID == product.ID)
                              let index = Array.IndexOf(productsArray, product)
                              select index)
        {
            productsArray = productsArray.Where((e, i) => i != index).ToArray();
            Config.productsLastIndex--;
            return;
        }

        throw new Exception("Product ID Not Exist");*/
    }
    #endregion
}
