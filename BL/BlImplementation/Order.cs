using BlApi;
using BO;

namespace BlImplementation;

internal class Order : IOrder
{
    private DalApi.IDal dal = new Dal.DalList();

    public BO.Order Get(int ID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderForList> GetAll()
    {
        throw new NotImplementedException();
    }

    public OrderTracking TrackOrder(int ID)
    {
        throw new NotImplementedException();
    }

    public BO.Order Update(int ID)
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
