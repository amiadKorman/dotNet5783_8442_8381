using DO;

namespace Dal;

public class DalOrder
{
    #region Add new order
    /// <summary>
    /// Add new order and before the create check if there is an Id exist
    /// </summary>
    /// <param name="newOrder"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void AddOrder(int Id, int CustomerId, DateTime OrderD, DateTime ShipD, DateTime DeliveryD)
    {
        if (OrderAreExist(Id))
        {
            throw new Exception("Order ID Are Exist");
        }
        // create new order
        Order NewOrder = new()
        {
            ID = Id,
            CustomerID = CustomerId,
            OrderDate = OrderD,
            ShipDate = ShipD,
            DeliveryDate = DeliveryD
        };
        Console.WriteLine("The new Order was successfully added\n");
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
        throw new Exception("Order ID Are not Exist");
    }
    #endregion

    #region Rerurn all Orders
    /// <summary>
    /// Print all the orders in the array
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
    public static void UpdateOrder(Order newOrder)
    {
        

        
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


    #region Order Are Exist
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IdOfOrder"></param>
    /// <returns>True if Order Are Exist False if Not</returns>
    public static bool OrderAreExist(int IdOfOrder)
    {
        // Run all over the Array and check if there is an Id exist
        foreach (OrderItem OItem in DataSource.orderItemsArray)
        {
            if (IdOfOrder == OItem.ID)
            {                
                return true;
            }
        }
        return false;
    }
    #endregion
}
