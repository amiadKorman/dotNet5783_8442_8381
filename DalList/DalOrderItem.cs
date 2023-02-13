using DO;
using DalApi;

namespace Dal;

/// <summary>
/// DalProduct class
/// </summary>
internal class DalOrderItem : IOrderItem
{
    DataSource ds = DataSource.instance;

    #region ADD
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <returns> order item ID </returns>
    public int Add(OrderItem orderItem)
    {
        orderItem.ID = DataSource.Config.NextOrderItemID;
        ds.orderItems.Add(orderItem);
        return orderItem.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return order item by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> order item </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public OrderItem Get(int id) => ds.orderItems.FirstOrDefault(oi => oi?.ID == id) ?? throw new DalDoesNotExistException("Order item ID doesn't exist");

    /// <summary>
    /// Return order item by given filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public OrderItem Get(Func<OrderItem?, bool>? filter) => ds.orderItems.Where(filter ?? throw new NullReferenceException("Filter can not be empty!")).FirstOrDefault() ?? throw new DalDoesNotExistException("Order item doesn't exist");

    /// <summary>
    /// Return all order items in DataSource by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns> filtered list of order items </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter) =>
        (filter == null ?
            ds.orderItems.Select(orderItem => orderItem) :
            ds.orderItems.Where(filter))
        ?? throw new DalDoesNotExistException("Missing order items");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Update(OrderItem orderItem)
    {
        int index = ds.orderItems.FindIndex(oi => oi?.ID == orderItem.ID);
        if (index == -1)
            throw new DalDoesNotExistException($"Order item with ID={orderItem.ID} doesn't exists");

        ds.orderItems[index] = orderItem;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order item by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        if (ds.orderItems.RemoveAll(oi => oi?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, order item ID doesn't exist");
    }
    #endregion
}
