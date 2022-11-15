using DO;
using System.Diagnostics;
using static Dal.DataSource;
using System.Linq;
using System;

namespace Dal;

public class DalOrderItem
{
    #region Add new order item
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

    #region Return order item by given ID
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
            throw new Exception("Order Item ID Not Exist");

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
        int index = Array.FindIndex(orderItemsArray, p => p.OrderID == orderID && p.ProductID == productID);
        if (index == -1)
            throw new Exception("Order Item ID Not Exist");

        return orderItemsArray[index];
    }
    #endregion

    #region Return All Order Items
    /// <summary>
    /// Return all the order items in the DataSource
    /// </summary>
    /// <returns>order items array</returns>
    public OrderItem[] ShowAllOrderItems()
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
    public OrderItem[] ShowAllOrderItems(int orderID)
    {
        OrderItem[] orderItems = Array.FindAll(orderItemsArray, oi => oi.OrderID == orderID);
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
        int index = Array.FindIndex(orderItemsArray, p => p.ID == newOrderItem.ID);
        if (index == -1)
            throw new Exception("Order Item ID Not Exist");

        orderItemsArray[index] = newOrderItem;

        /*for (int i = 0; i < Config.orderItemsLastIndex; i++)
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

        throw new Exception("Product ID Not Exist");*/
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
        int index = Array.FindIndex(orderItemsArray, p => p.ID == orderItemID);
        if (index == -1)
            throw new Exception("Order Item ID Not Exist");

        orderItemsArray = orderItemsArray.Where((e, i) => i != index).ToArray();
        Config.orderItemsLastIndex--;
        return;

        /*foreach (var index in from OrderItem OrderItem in orderItemsArray
                              where OrderItem.ID == orderItemID
                              let index = Array.IndexOf(orderItemsArray, OrderItem)
                              select index)
        {
            orderItemsArray = orderItemsArray.Where((e, i) => i != index).ToArray();
            Config.orderItemsLastIndex--;
            return;
        }

        throw new Exception("Order Item ID Not Exist");*/
    }
    #endregion
}
