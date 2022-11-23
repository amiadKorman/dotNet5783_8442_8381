﻿using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalOrderItem : IOrderItem
{
    #region ADD
    /// <summary>
    /// Add new order item
    /// </summary>
    /// <param name="orderItem"></param>
    /// <returns>order item ID</returns>
    public int Add(OrderItem orderItem)
    {
        orderItem.ID = Config.NextOrderItemID;
        orderItems.Add(orderItem);
        return orderItem.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return order item by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> order item </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public OrderItem GetById(int id) => orderItems.FirstOrDefault(oi => oi?.ID == id) ?? throw new DalDoesNotExistException("Order item ID doesn't exist");


    /// <summary>
    /// Return all the order items in the DataSource
    /// </summary>
    /// <returns>order items array</returns>
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter)
    {
        OrderItem[] orderItems = new OrderItem[orderItemsLastIndex];
        Array.Copy(orderItemsArray, orderItems, orderItems.Length);
        return orderItems;
    }

    /// <summary>
    /// Return all the order items of specific order
    /// </summary>
    /// <param name="orderID"></param>
    /// <returns>order item array</returns>
    public List<OrderItem> GetByOrderId(int orderID)
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
    public void Update(OrderItem orderItem)
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
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        if (orderItems.RemoveAll(oi => oi?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, order item ID doesn't exist");
    }
    #endregion
}
 