using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalOrder : IOrder
{
    #region ADD
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns>order ID</returns>
    public int Add(Order order)
    {
        order.ID = Config.NextOrderID;
        orders.Add(order);
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
    public Order GetById(int id) => orders.FirstOrDefault(o => o?.ID == id) ?? throw new DalDoesNotExistException("Order ID doesn't exist");

    /// <summary>
    /// Return all the orders in the DataSource
    /// </summary>
    /// <returns>all orders</returns>
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter) =>
        (filter == null ?
            orders.Select(order => order) :
            orders.Where(filter))
        ?? throw new DalDoesNotExistException("Missing orders");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update order
    /// </summary>
    /// <param name="newOrder"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Order order)
    {
        int index = Array.FindIndex(ordersArray, o => o.ID == newOrder.ID);
        if (index == -1)
            throw new Exception("Order ID doesn't exist");

        ordersArray[index] = newOrder;
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
        if (orders.RemoveAll(o => o?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, order ID doesn't exist");
    }
    #endregion
}
