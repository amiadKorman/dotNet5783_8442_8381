using BlApi;

namespace BlImplementation;

internal class Order : IOrder
{
    private DalApi.IDal dal = new Dal.DalList();

    public BO.Order Get(int ID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.OrderForList> GetAll()
    {
        throw new NotImplementedException();
    }

    public BO.OrderTracking TrackOrder(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Order Update(BO.Order order)
    {
        throw new NotImplementedException();
    }

    public BO.Order UpdateDelivery(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Order UpdateShipping(int ID)
    {
        throw new NotImplementedException();
    }
}
