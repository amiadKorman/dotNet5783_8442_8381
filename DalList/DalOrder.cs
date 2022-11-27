using DO;
using DalApi;

namespace Dal;

internal class DalOrder : IOrder
{
    DataSource ds = DataSource.instance;
    #region ADD
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns> order ID </returns>
    public int Add(Order order)
    {
        order.ID = DataSource.Config.NextOrderID;
        ds.orders.Add(order);
        return order.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return order by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> order </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public Order GetById(int id) => ds.orders.FirstOrDefault(o => o?.ID == id) ?? throw new DalDoesNotExistException("Order ID doesn't exist");

    /// <summary>
    /// Return all orders in DataSource by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns> filtered list of orders </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter) =>
        (filter == null ?
            ds.orders.Select(order => order) :
            ds.orders.Where(filter))
        ?? throw new DalDoesNotExistException("Missing orders");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update order
    /// </summary>
    /// <param name="order"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Update(Order order)
    {
        int index = ds.orders.FindIndex(o => o?.ID == order.ID);
        if (index == -1)
            throw new DalDoesNotExistException($"Order with ID={order.ID} doesn't exists");

        ds.orders[index] = order;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        if (ds.orders.RemoveAll(o => o?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, order ID doesn't exist");
    }
    #endregion
}
