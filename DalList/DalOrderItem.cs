using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    #region Add new order item
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="OItemID"></param>
    /// <param name="Orderid"></param>
    /// <param name="ProductId"></param>
    /// <param name="Price"></param>
    /// <param name="Amount"></param>
    /// <returns>new order item ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddOrderItem(int Orderid, int ProductId, double Price, int Amount)
    {
        /*foreach (var _ in from OrderItem OItem in orderItemsArray
                          where Orderid == OItem.OrderID
                          select new { })
        {
            throw new Exception("Order Item ID Already Exist");
        }*/

        OrderItem newOrderItem = new()
        {
            ID = Config.GetOrderItemID,
            OrderID = Orderid,
            ProductID = ProductId,
            Price = Price,
            Amount = Amount
        };
        return newOrderItem.ID;
    }
    #endregion

    #region Return order by given ID
    /// <summary>
    /// Return order by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <returns>order item</returns>
    /// <exception cref="Exception"></exception>
    public OrderItem GetOrderItem(int orderItemID)
    {
        foreach (var OItem in from OrderItem OItem in orderItemsArray
                              where orderItemID == OItem.ID
                              select OItem)
        {
            return OItem;
        }

        throw new Exception("Order Item ID Not Exist");
    }
    #endregion

    #region Return All Order Item
    /// <summary>
    /// Return all the order items in the DataSource
    /// </summary>
    /// <returns>all order items</returns>
    public OrderItem[] ShowAllOrderItems()
    {
        OrderItem[] orderItems = new OrderItem[Config.orderItemsLastIndex];
        Array.Copy(orderItemsArray, orderItems, orderItems.Length);
        return orderItems;
    }
    #endregion

    #region Update order item by given ID
    /// <summary>
    /// Update order item by given ID
    /// </summary>
    /// <param name="newOrderItem"></param>
    /// <exception cref="Exception"></exception>
    public void UpdateOrderItem(OrderItem newOrderItem)
    {
        for (int i = 0; i < Config.orderItemsLastIndex; i++)
        {
            if (newOrderItem.ID == orderItemsArray[i].ID)
            {
                if (newOrderItem.ProductID != 0)
                    orderItemsArray[i].ProductID = newOrderItem.ProductID;
                if (newOrderItem.OrderID != 0)
                    orderItemsArray[i].OrderID = newOrderItem.OrderID;
                if (newOrderItem.Price != 0.0)
                    orderItemsArray[i].Price = newOrderItem.Price;
                if (newOrderItem.Amount != 0)
                    orderItemsArray[i].Amount = newOrderItem.Amount;
                return;
            }
        }

        throw new Exception("Product ID Not Exist");
    }
    #endregion

    #region Delete order item by given ID
    /// <summary>
    /// Delete order item by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <exception cref="Exception"></exception>
    public void DeleteOrderItem(int orderItemID)
    {
        foreach (OrderItem OrderItem in orderItemsArray)
        {
            if (OrderItem.ID == orderItemID)
            {
                int index = Array.IndexOf(orderItemsArray, OrderItem);
                orderItemsArray = orderItemsArray.Where((e, i) => i != index).ToArray();
                Config.orderItemsLastIndex--;
                return;
            }
        }
        throw new Exception("Order Item ID Not Exist");
    }
    #endregion
}
