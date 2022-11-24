using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalOrderItem : IOrderItem
{
    #region ADD
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <returns> order item ID </returns>
    public int Add(OrderItem orderItem)
    {
        orderItem.ID = Config.NextOrderItemID;
        orderItems.Add(orderItem);
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
    public OrderItem GetById(int id) => orderItems.FirstOrDefault(oi => oi?.ID == id) ?? throw new DalDoesNotExistException("Order item ID doesn't exist");

    /// <summary>
    /// Return all order items in DataSource by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns> filtered list of order items </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter) =>
        (filter == null ?
            orderItems.Select(orderItem => orderItem) :
            orderItems.Where(filter))
        ?? throw new DalDoesNotExistException("Missing order items");

    /// <summary>
    /// Return all the order items of specific order
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns> list of order items with same order id </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<OrderItem?> GetByOrderId(int orderID) => orderItems.Where(oi => oi?.OrderID == orderID) ?? throw new DalDoesNotExistException("Order item ID doesn't exist");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Update(OrderItem orderItem)
    {
        int index = orderItems.FindIndex(oi => oi?.ID == orderItem.ID);
        if (index == -1)
            throw new DalDoesNotExistException($"Order item with ID={orderItem.ID} doesn't exists");

        orderItems[index] = orderItem;
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
        if (orderItems.RemoveAll(oi => oi?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, order item ID doesn't exist");
    }
    #endregion
}
