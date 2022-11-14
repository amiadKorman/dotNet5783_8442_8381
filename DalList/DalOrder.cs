using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    #region Add new order
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns>new order ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddOrder(Order order)
    {
        int result = Array.FindIndex(ordersArray, o => o.ID == order.ID);
        if (result == -1)
            throw new Exception("Order ID Already Exist");
        ordersArray[Config.ordersLastIndex++] = new()
        {
            ID = Config.GetOrderID,
            CustomerID = order.CustomerID,
            OrderDate = order.OrderDate,
            ShipDate = order.ShipDate,
            DeliveryDate = order.DeliveryDate
        };
        return order.ID;
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
    /// <exception cref="Exception"></exception>
    public void UpdateOrder(Order newOrder)
    {
        for (int i = 0; i < Config.ordersLastIndex; i++)
        {
            if (newOrder.ID == ordersArray[i].ID)
            {
                if (newOrder.CustomerID != 0)
                    ordersArray[i].CustomerID = newOrder.CustomerID;
                if (newOrder.ShipDate != null)
                    ordersArray[i].ShipDate = newOrder.ShipDate;
                if (newOrder.DeliveryDate != null)
                    ordersArray[i].DeliveryDate = newOrder.DeliveryDate;
                return;
            }
        }

        throw new Exception("Order ID Not Exist");
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
