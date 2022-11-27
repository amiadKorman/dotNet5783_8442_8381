namespace DalApi;

public interface IDal
{
    ICustomer Customer { get; }
    IOrder Order { get; }
    IOrderItem OrderItem { get; }
    IProduct Product { get; }
}
