using DO;

namespace DalApi;

public interface IOrderItem : ICrud<OrderItem>
{
    IEnumerable<OrderItem?> GetByOrderId(int id);
}
