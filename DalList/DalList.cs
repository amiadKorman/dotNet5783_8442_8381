using DalApi;

namespace Dal;

sealed public class DalList : IDal
{
    public static IDal Instance { get; } = new DalList();
    private DalList() { }

    public ICustomer Customer => new DalCustomer();

    public IOrder Order => new DalOrder();

    public IOrderItem OrderItem => new DalOrderItem();

    public IProduct Product => new DalProduct();
}