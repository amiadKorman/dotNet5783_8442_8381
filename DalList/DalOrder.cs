using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    #region Add new order
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="UD"></param>
    /// <param name="CustomerID"></param>
    /// <param name="OrderD"></param>
    /// <param name="ShipD"></param>
    /// <param name="DeliveryD"></param>
    /// <returns>new order ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddOrder(int UD, int CustomerID, DateTime OrderD, DateTime ShipD, DateTime DeliveryD)
    {
        if (OrderAreExist(UD))
        {
            throw new Exception("Order ID Already Exist");
        }
        // create new order
        Order NewOrder = new()
        {
            ID = Config.GetOrderID,
            CustomerID = CustomerID,
            OrderDate = OrderD,
            ShipDate = ShipD,
            DeliveryDate = DeliveryD
        };

        return NewOrder.ID;
    }
    #endregion

    #region Return order by given ID
    /// <summary>
    /// Return order by given ID
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns>order</returns>
    /// <exception cref="Exception"></exception>
    public Order GetOrder(int orderID)
    {
        foreach (var order in ordersArray.Where(order => orderID == order.ID))
        {
            return order;
        }

        throw new Exception("Order ID Not Exist");
    }
    #endregion

    #region Rerurn all Orders
    /// <summary>
    /// Return all the orders in the DataSource
    /// </summary>
    /// <returns>all orders</returns>
    public Order[] ShowAllOrders()
    {
        Order[] orders = new Order[Config.ordersLastIndex];
        Array.Copy(ordersArray, orders, orders.Length);
        return orders;
    }

    #endregion

    #region Update order by given ID
    /// <summary>
    /// Update order by given ID
    /// </summary>
    /// <param name="newOrder"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public void UpdateOrder(Order newOrder)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete order by given ID
    /// <summary>
    /// Delete order by given ID
    /// </summary>
    /// <param name="orderID"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void DeleteOrder(int orderID)
    {
        foreach (Order order in ordersArray)
        {
            if (orderID == order.ID)
            {
                int index = Array.IndexOf(ordersArray, order);
                ordersArray = ordersArray.Where((e, i) => i != index).ToArray();
                Config.ordersLastIndex--;
                return;
            }
        }
        throw new Exception("Order ID Not Exist");
    }
    #endregion

    #region Order Are Exist
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IdOfOrder"></param>
    /// <returns>True if Order Are Exist False if Not</returns>
    public bool OrderAreExist(int IdOfOrder)
    {
        foreach (var _ in ordersArray.Where(order => IdOfOrder == order.ID).Select(
        // Run all over the Array and check if there is an Id exist
        order => new { }))
        {
            return true;
        }

        return false;
    }
    #endregion
}
