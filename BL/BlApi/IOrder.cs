using BO;

namespace BlApi;

public interface IOrder
{
    public IEnumerable<OrderForList> GetOrders();
    public Order GetOrderById(int id);
    public Order UpdateShipping(int id);
    public Order UpdateDelivery(int id);
    public OrderTracking TrackOrder(int id);
    public Order Update(int id);
}
