﻿using DO;

namespace Dal;

public class DalProduct
{

    #region Add new product item
    /// <summary>
    /// Add new product item
    /// </summary>
    /// <param name="newProdect"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void AddProduct(int Id, string nameP,double price, CategoryOfProduct category, int InStock)
    {
        foreach (OrderItem OItem in DataSource.orderItemsArray)
        {
            if (Id == OItem.ID)
            {
                throw new Exception("product ID Are Exist");

            }
        }
        Product NewProduct = new Product
        {
            ID = Id,
            Name = nameP,
            Price = price,
            Category = category,
            InStock = InStock
        };
    }
    #endregion

    #region Return product by given
    /// <summary>
    /// Return product by given
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Product GetProduct(int productID)
    {
        foreach (Product product in DataSource.productsArray)
        {
            if (productID == product.ID)
            {
                return product;
            }
        }
        throw new NotImplementedException();
    }
    #endregion

    #region Return all products
    public static void ShowAllProdoct()
    {
        foreach (Product p in DataSource.productsArray)
        {
            p.ToString();

        }
    }

    #endregion

    #region Update product item by given ID
    /// <summary>
    /// Update product item by given ID
    /// </summary>
    /// <param name="newProduct"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Product UpdateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete product item by given ID
    /// <summary>
    /// Delete product item by given ID
    /// </summary>
    /// <param name="productID"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void DeleteProduct(int productID)
    {
        foreach (Product product in DataSource.productsArray)
        {
            if (productID == product.ID)
            {
                int index = Array.IndexOf(DataSource.productsArray, product);
                DataSource.productsArray = DataSource.productsArray.Where((e, i) => i != index).ToArray();
            }
        }
        
        throw new NotImplementedException();
    }
    #endregion

}
