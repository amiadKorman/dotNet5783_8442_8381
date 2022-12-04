using BlApi;

namespace BlImplementation;

internal class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    public void Add(BO.Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Product Get(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.ProductItem Get(int ID, BO.Cart cart)
    {
        throw new NotImplementedException();
    }

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

    public void Update(BO.Product product)
    {
        throw new NotImplementedException();
    }
}
