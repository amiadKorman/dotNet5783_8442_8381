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
    /// <param name="orderID"></param>
    /// <returns>order</returns>
    /// <exception cref="Exception"></exception>
    public Order GetById(int id)
    {
        int index = Array.FindIndex(ordersArray, o => o.ID == orderID);
        if (index == -1)
            throw new Exception("Order ID doesn't exist");

        return ordersArray[index];
    }

    /// <summary>
    /// Return all the orders in the DataSource
    /// </summary>
    /// <returns>all orders</returns>
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter)
    {
        Order[] orders = new Order[ordersLastIndex];
        Array.Copy(ordersArray, orders, orders.Length);
        return orders;
    }
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
    /// <param name="orderID"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderID);
        if (index == -1)
            throw new Exception("Order ID doesn't exist");

        ordersArray = ordersArray.Where((e, i) => i != index).ToArray();
        ordersLastIndex--;
        return;
    }
    #endregion
}
