using DO;

namespace Dal;

public class DalOrderItem
{
    #region Add new order item
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="newOrderItem"></param>
    /// <exception cref="Throw New Exception"></exception>
    public static void AddOrderItem(int Orderid, int ProductId, double priceOr, int AmountOr)
    {
        foreach (OrderItem OItem in DataSource.orderItemsArray)
        {
            if (Orderid == OItem.ID)
            {
                throw new Exception("Order Item ID Are Exist");
                
            }
        }
        OrderItem newOrderItem= new()
        {
            OrderID = Orderid,
            ProductID = ProductId,
            Price = priceOr,
            Amount = AmountOr
        };
    }
    #endregion

    #region Return order by given ID
    /// <summary>
    /// Return order by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static OrderItem GetOrderItem(int orderItemID)
    {
        foreach (OrderItem OItem in DataSource.orderItemsArray)
        {
            if (orderItemID == OItem.ID)
            {
                return OItem;
            }
        }
        throw new Exception("Order Item ID Not Exist");
    }
    #endregion

    #region Return All Order Item
    /// <summary>
    /// 
    /// </summary>
    public static void ShowAllOrderItems()
    {
        foreach (OrderItem orderItem in DataSource.orderItemsArray)
        {
            Console.WriteLine(orderItem);
        }
    }

    #endregion

    #region Update order item by given ID
    /// <summary>
    /// Update order item by given ID
    /// </summary>
    /// <param name="newOrderItem"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public OrderItem UpdateOrderItem(OrderItem newOrderItem)
    {


        throw new NotImplementedException();
    }
    #endregion

    #region Delete order item by given ID
    /// <summary>
    /// Delete order item by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void DeleteOrderItem(int orderItemID)
    {
        foreach (OrderItem OrderItem in DataSource.orderItemsArray)
        {
            if (OrderItem.ID == orderItemID)
            {
                int index = Array.IndexOf(DataSource.orderItemsArray, OrderItem);
                DataSource.orderItemsArray = DataSource.orderItemsArray.Where((e, i) => i != index).ToArray();
                return;
            }
        }
        throw new Exception("Order Item ID Not Exist");
    }
    #endregion
}
