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
                Category = (DO.CategoryOfProduct?)product.Category,
                InStock = product.InStock
            });
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException("Product already exist", ex);
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
                Category = (DO.CategoryOfProduct?)product.Category,
                InStock = product.InStock
            });
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Product doesn't exist", ex);
        }
    }
    #endregion

    #region Get
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
            DO.Product? product = dal.Product.Get(ID);
            return new BO.Product
            {
                ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
                InStock = product?.InStock ?? throw new NullReferenceException("Missing stock amount")
            };
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Product doesn't exist", ex);
        }
    }

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
            DO.Product? product = dal.Product.Get(ID);
            var PI = new BO.ProductItem
            {
                ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
                InStock = product?.InStock > 0 ? true : false
            };

            if (cart.Items != null)
            {
                foreach (var item in cart.Items)
                {
                    if (item?.ProductID == ID)
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
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Product doesn't exist", ex);
        }
    }

    /// <summary>
    /// Get all products details from store database, for manager screens
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public IEnumerable<BO.ProductForList> GetList()
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

    /// <summary>
    /// Get all products details from store database, for buyer catalog screen
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public IEnumerable<BO.ProductItem> GetCatalog()
    {
        return from product in dal.Product.GetAll()
               select new BO.ProductItem
               {
                   ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                   Name = product?.Name ?? throw new NullReferenceException("Missing Name"),
                   Price = product?.Price ?? throw new NullReferenceException("Missing Price"),
                   Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
                   Amount = product?.InStock ?? throw new NullReferenceException("Missing Amount in stock"),
                   InStock = product?.InStock > 0 ? true : false
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

        foreach (var orderItem in dal.OrderItem.GetAll())
        {
            if (orderItem?.ID == ID)
                throw new BO.BlAlreadyExistsException("Cannot delete product in existing order");
        }

        try
        {
            dal.Product.Delete(ID);
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Product doesn't exist", ex);
        }
    }
    #endregion
}
