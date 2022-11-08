using DO;

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
        Product NewProduct = new Product();
        NewProduct.ID = Id;
        NewProduct.Name = nameP;
        NewProduct.Price = price;
        NewProduct.Category = category;
        NewProduct.InStock = InStock;

        //DataSource.productsArray[0] = NewProduct;  

        throw new NotImplementedException();
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
