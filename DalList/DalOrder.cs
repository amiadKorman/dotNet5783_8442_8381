using DO;
using static Dal.DataSource;
using System.Linq;

namespace Dal;

public class DalOrder
{
    #region ADD
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns>new order ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddOrder(Order order)
    {
        ordersArray[Config.ordersLastIndex++] = new()
        {
            ID = Config.GetOrderID,
            CustomerID = order.CustomerID,
            OrderDate = DateTime.Now,
        };
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
    public Order GetOrder(int orderID)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderID);
        if (index == -1)
            throw new Exception("Order ID doesn't exist");

        return ordersArray[index];
    }

    /// <summary>
    /// Return all the orders in the DataSource
    /// </summary>
    /// <returns>all orders</returns>
    public Order[] GetAllOrders()
    {
        Order[] orders = new Order[Config.ordersLastIndex];
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
    public void UpdateOrder(Order newOrder)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == newOrder.ID);
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
    public void DeleteOrder(int orderID)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderID);
        if (index == -1)
            throw new Exception("Order ID doesn't exist");

        ordersArray = ordersArray.Where((e, i) => i != index).ToArray();
        Config.ordersLastIndex--;
        return;
    }
    #endregion
}
