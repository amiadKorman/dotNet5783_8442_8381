using BlApi;

namespace BlImplementation;

/// <summary>
/// Logic product entity
/// </summary>
internal class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    #region Add
    /// <summary>
    /// Add product to store database, for manager screen
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlAlreadyExistsException"></exception>
    public void Add(BO.Product product)
    {
        //validation check of product fields 
        if (product.ID < 100000 || product.ID >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");
        if (product.Name == null)
            throw new BO.BlInvalidFieldException("Product name cannot be empty");
        if (product.Price < 0)
            throw new BO.BlInvalidFieldException("Product price cannot be negative");
        if (product.InStock < 0)
            throw new BO.BlInvalidFieldException("Product amount in stock cannot be negative");
        try
        {
            dal.Product.Add(new DO.Product
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (DO.CategoryOfProduct)product.Category,
                InStock = product.InStock
            });
        }
        catch (Exception ex)
        {
            throw new BO.BlAlreadyExistsException("add product failed", ex);
        }
    }
    #endregion

    #region Update
    /// <summary>
    /// Update product in store database, for manager screen
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public void Update(BO.Product product)
    {
        //validation check of product fields 
        if (product.ID < 100000 || product.ID >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");
        if (product.Name == null)
            throw new BO.BlInvalidFieldException("Product name cannot be empty");
        if (product.Price < 0)
            throw new BO.BlInvalidFieldException("Product price cannot be negative");
        if (product.InStock < 0)
            throw new BO.BlInvalidFieldException("Product amount in stock cannot be negative");

        try
        {
            dal.Product.Update(new DO.Product
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (DO.CategoryOfProduct)product.Category,
                InStock = product.InStock
            });
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        }
    }
    #endregion

    #region Get by ID
    /// <summary>
    /// Get product details from the store, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public BO.Product Get(int ID)
    {
        if (ID < 100000 || ID >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");

        try
        {
            DO.Product? product = dal.Product.GetById(ID);
            return new BO.Product
            {
                ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
                InStock = product?.InStock ?? throw new NullReferenceException("Missing stock amount")
            };
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        }
    }
    #endregion

    /// <summary>
    /// Get product item details from the store, for catalog customer screen
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="cart"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public BO.ProductItem Get(int ID, BO.Cart cart)
    {
        if (ID < 100000 || ID >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");

        try
        {
            DO.Product? product = dal.Product.GetById(ID);
            var PI = new BO.ProductItem
            {
                ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
                Amount = product?.InStock ?? throw new NullReferenceException("Missing stock amount"),
                InStock = product?.InStock > 0 ? true : false
            };

            if (cart.Items != null)
            {
                foreach (var item in cart.Items)
                {
                    if (item.ID == ID)
                    {
                        PI.Amount = item.Amount;
                        break;
                    }
                }
            }
            else
            {
                PI.Amount = 0;
            }
            return PI;
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        }
    }

    #region Get All
    /// <summary>
    /// Get all products details from store database, for manager and catalog customer screens
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public IEnumerable<BO.ProductForList> GetAll()
    {
        return from product in dal.Product.GetAll()
               select new BO.ProductForList
               {
                   ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                   Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                   Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                   Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
               };
    }
    #endregion

    #region Delete
    /// <summary>
    /// Delete product from store database, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlAlreadyExistsException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public void Delete(int ID)
    {
        if (ID < 100000 || ID >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");

        foreach (DO.OrderItem orderItem in dal.OrderItem.GetAll())
        {
            if (orderItem.ID == ID)
                throw new BO.BlAlreadyExistsException("Cannot delete product in existing order");
        }

        try
        {
            dal.Product.Delete(ID);
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        }
    }
    #endregion
}
