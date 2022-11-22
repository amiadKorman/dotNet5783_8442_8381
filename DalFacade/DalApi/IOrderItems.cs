using DO;

namespace DalApi;

public interface IOrderItem : ICrud<OrderItem>
{
    List<OrderItem> GetOrderItems(int id);
}
