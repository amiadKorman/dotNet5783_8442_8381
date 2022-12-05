using BlApi;
using BO;

namespace BlImplementation;

internal class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    /// <summary>
    /// Add new product to the list
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(BO.Product product)
    {
        DO.Product add_product = new DO.Product()
        {
            Name = product.Name,
            Price = product.Price,
            Category = (DO.CategoryOfProduct)product.Category,
            InStock = product.InStock
        };
        dal.Product.Add(add_product);

    }

    /// <summary>
    /// Update product details
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(BO.Product product)
    {
        DO.Product DOProduct = new DO.Product()
        {
            ID = product.ID,
            Name = product.Name,
            Price = product.Price,
            InStock = product.InStock,
            Category = (DO.CategoryOfProduct)product.Category
        };
        dal.Product.Update(DOProduct);
    }

    /// <summary>
    ///  Get product by <paramref name="ID"/>
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BO.Product Get(int ID)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="cart"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ProductItem Get(int ID, BO.Cart cart)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// print all product are axsiste
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
                   Price = product?.Price ?? 0d,
                   Category = (BO.Category?)product?.Category ?? throw new NullReferenceException("Missing product category"),
               };
    }

    /// <summary>
    /// Delete product by <paramref name="ID"/>
    /// </summary>
    /// <param name="ID"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Delete(int ID)
    {
       
            IEnumerable<DO.Product?> products = dal.Product.GetAll();
            List<ProductForList> BOProducts = new List<BO.ProductForList>();
            foreach (DO.Product product in products)
            {
                BOProducts.Add(new ProductForList()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Category = (Category)product.Category
                });
            }
            return BOProducts;
        
       
    }

   

   
}
