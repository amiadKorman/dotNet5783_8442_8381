using DO;
using static Dal.DataSource;

namespace Dal;

public class DalProduct
{
    #region Add new product item
    /// <summary>
    /// Add new product item
    /// </summary>
    /// <param name="newProdect"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static int AddProduct(int ID, string nameP, double price, CategoryOfProduct category, int InStock)
    {
        foreach (var _ in from OrderItem OItem in orderItemsArray
                          where ID == OItem.ID
                          select new { })
        {
            throw new Exception("product ID Already Exist");
        }

        productsArray[Config.productsLastIndex++] = new()
        {
            ID = ID,
            Name = nameP,
            Price = price,
            Category = category,
            InStock = InStock
        };
        return ID;
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
        foreach (var product in from Product product in productsArray
                                where productID == product.ID
                                select product)
        {
            return product;
        }

        throw new Exception("Product ID Not Exist");
    }
    #endregion

    #region Return all products
    /// <summary>
    /// Return all the products in the DataSource
    /// </summary>
    public static Product[] ShowAllProdoct()
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
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static void UpdateProduct(Product newProduct)
    {
        for(int i = 0; i < Config.productsLastIndex; i++)
        {
            if (newProduct.ID == productsArray[i].ID)
            {
                if (newProduct.Name != "")
                    productsArray[i].Name = newProduct.Name;
                if(newProduct.Price != 0)
                    productsArray[i].Price = newProduct.Price;
                if(newProduct.Category != 0)
                    productsArray[i].Category = newProduct.Category;
                if(newProduct.InStock != 0)
                    productsArray[i].InStock = newProduct.InStock;
                return;
            }
        }

        throw new Exception("Product ID Not Exist");
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
        foreach (var product in productsArray.Where(product => productID == product.ID))
        {
            int index = Array.IndexOf(productsArray, product);
            productsArray = productsArray.Where((e, i) => i != index).ToArray();
            Config.productsLastIndex--;
            return;
        }

        throw new Exception("Product ID Not Exist");
    }
    #endregion
}
