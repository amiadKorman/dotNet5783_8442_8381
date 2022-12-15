using DalApi;

namespace Dal;

sealed public class DalList : IDal
{
    public ICustomer Customer { get; } = new DalCustomer();

    public IOrder Order { get; } = new DalOrder();

    public IOrderItem OrderItem { get; } = new DalOrderItem();

    public IProduct Product { get; } = new DalProduct();
}