using DO;
using System.Diagnostics;
using static Dal.DataSource;
using System.Linq;
using System;

namespace Dal;

public class DalOrderItem
{
    #region ADD
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <returns>new order item ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddOrderItem(OrderItem orderItem)
    {
        orderItemsArray[Config.orderItemsLastIndex++] = new()
        {
            ID = Config.GetOrderItemID,
            OrderID = orderItem.OrderID,
            ProductID = orderItem.ProductID,
            Price = orderItem.Price,
            Amount = orderItem.Amount
        };
        return orderItem.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return order item by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <returns>order item</returns>
    /// <exception cref="Exception"></exception>
    public OrderItem GetOrderItem(int orderItemID)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderItemID);
        if (index == -1)
            throw new Exception("Order item ID doesn't exist");

        return orderItemsArray[index];
    }

    /// <summary>
    /// Return order item by given order and product ID
    /// </summary>
    /// <param name="orderID"></param>
    /// <param name="productID"></param>
    /// <returns>order item</returns>
    /// <exception cref="Exception"></exception>
    public OrderItem GetOrderItem(int orderID, int productID)
    {
        int index = Array.FindIndex(orderItemsArray, oi => oi.OrderID == orderID && oi.ProductID == productID);
        if (index == -1)
            throw new Exception("Order item like this doesnwt exist");

        return orderItemsArray[index];
    }

    /// <summary>
    /// Return all the order items in the DataSource
    /// </summary>
    /// <returns>order items array</returns>
    public OrderItem[] GetAllOrderItems()
    {
        OrderItem[] orderItems = new OrderItem[Config.orderItemsLastIndex];
        Array.Copy(orderItemsArray, orderItems, orderItems.Length);
        return orderItems;
    }

    /// <summary>
    /// Return all the order items of specific order
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns>order item array</returns>
    public OrderItem[] GetAllOrderItems(int orderID)
    {
        OrderItem[] orderItems = Array.FindAll(orderItemsArray, oi => oi.OrderID == orderID);

        if (orderItems.Length == 0)
            throw new Exception("Order item like this doesn't exist");

        return orderItems;
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update order item
    /// </summary>
    /// <param name="newOrderItem"></param>
    /// <exception cref="Exception"></exception>
    public void UpdateOrderItem(OrderItem newOrderItem)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == newOrderItem.ID);
        if (index == -1)
            throw new Exception("Order item ID doesn't exist");

        orderItemsArray[index] = newOrderItem;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete order item by given ID
    /// </summary>
    /// <param name="orderItemID"></param>
    /// <exception cref="Exception"></exception>
    public void DeleteOrderItem(int orderItemID)
    {
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderItemID);
        if (index == -1)
            throw new Exception("Order item ID doesn't exist");

        orderItemsArray = orderItemsArray.Where((e, i) => i != index).ToArray();
        Config.orderItemsLastIndex--;
    }
    #endregion
}
