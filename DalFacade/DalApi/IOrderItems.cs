using DO;

namespace DalApi;

public interface IOrderItem : ICrud<OrderItem>
{
    OrderItem GetByOrderAndProductId(int orderID, int productID);
}
