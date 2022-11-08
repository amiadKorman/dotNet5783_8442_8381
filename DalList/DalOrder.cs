using DO;

namespace Dal;

public class DalOrder
{
    #region Add new order
    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="newOrder"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void AddOrder(int Id, int CustomerId, DateTime OrderD, DateTime ShipD, DateTime DeliveryD)
    {
        foreach (OrderItem OItem in DataSource.orderItemsArray)
        {
            if (Id == OItem.ID)
            {
                throw new Exception("Order ID Are Exist");

            }
        }

        Order NewOrder = new()
        {
            ID = Id,
            CustomerID = CustomerId,
            OrderDate = OrderD,
            ShipDate = ShipD,
            DeliveryDate = DeliveryD
        };

        throw new NotImplementedException();
    }
    #endregion

    #region Return order by given ID
    /// <summary>
    /// Return order by given ID
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Order GetOrder(int orderID)
    {
        foreach (Order order in DataSource.ordersArray)
        {
            if (orderID == order.ID)
            {
                return order;
            }

        }
        throw new NotImplementedException();
    }
    #endregion

    #region Rerurn all Orders
    /// <summary>
    /// 
    /// </summary>
    public static void ShowAllOrders()
    {
        foreach (Order order in DataSource.ordersArray)
        {
            Console.WriteLine(order);
          
        }
    }

    #endregion

    #region Update order by given ID
    /// <summary>
    /// Update order by given ID
    /// </summary>
    /// <param name="newOrder"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Order UpdateOrder(Order newOrder)
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
    public static void DeleteOrder(int orderID)
    {
        int i = 0;
        foreach (Order order in DataSource.ordersArray)
        {
            if (orderID == order.ID)
            {
                int index = Array.IndexOf(DataSource.ordersArray, order);
                DataSource.ordersArray = DataSource.ordersArray.Where((e, i) => i != index).ToArray();
            }
        }
        throw new NotImplementedException();
    }
    #endregion
}
