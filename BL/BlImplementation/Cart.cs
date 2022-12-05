using BlApi;
namespace BlImplementation;

internal class Cart : ICart
{
    private DalApi.IDal dal = new Dal.DalList();

    public BO.Cart Add(BO.Cart cart, int productId)
    {
        
        throw new NotImplementedException();
    }

    public void Buy(BO.Cart cart)
    {
        throw new NotImplementedException();
    }

    public BO.Cart Update(BO.Cart cart, int productId, int amount)
    {
        throw new NotImplementedException();
    }
}
