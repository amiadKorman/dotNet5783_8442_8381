using BlApi;
using BO;

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

    public ProductItem Get(int ID, BO.Cart cart)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductForList> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(BO.Product product)
    {
        throw new NotImplementedException();
    }
}
