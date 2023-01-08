﻿using BlApi;

namespace BlImplementation;

internal class Order : BlApi.IOrder
{
    private DalApi.IDal dal = new Dal.DalList();

    #region get by ID
    /// <summary>
    /// Get order details from database, for manager and customer screens
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="BO.BlFailedException"></exception>
    public BO.Order Get(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");

        try
        {
            DO.Order? doOrder = dal.Order.GetById(ID);
            BO.Order boOrder = new()
            {
                ID = doOrder?.ID ?? throw new NullReferenceException("Missing ID"),
                CustomerID = doOrder?.CustomerID ?? throw new NullReferenceException("Missing customer ID"),
                OrderDate = doOrder?.OrderDate ?? throw new NullReferenceException("Missing order date"),
                ShipDate = doOrder?.ShipDate ?? throw new NullReferenceException("Missing ship date"),
                DeliveryDate = doOrder?.DeliveryDate ?? throw new NullReferenceException("Missing delivery date"),
                Status = CalcStatus(doOrder),
                Items = from oi in dal.OrderItem.GetAll(oi => oi?.OrderID == ID)
                        select new BO.OrderItem
                        {
                            ID = oi?.ID ?? throw new NullReferenceException("Missing ID"),
                            Price = oi?.Price ?? throw new NullReferenceException("Missing price"),
                            Amount = oi?.Amount ?? throw new NullReferenceException("Missing amount"),
                            ProductID = oi?.ProductID ?? throw new NullReferenceException("Missing product ID"),
                            TotalPrice = oi?.Amount * oi?.Price ?? throw new NullReferenceException("Missing amount or price"),
                            Name = dal.Product.GetById(oi?.ProductID ?? throw new NullReferenceException("Missing product ID")).Name
                        }
            };
            boOrder.TotalPrice = boOrder.Items.Sum(oi => oi.TotalPrice);
            return boOrder;
        }
        catch (Exception ex)
        {
            throw new BO.BlFailedException("Failed to get order details", ex);
        }
    }
    #endregion

    #region get All
    /// <summary>
    /// Get all orders from store database, for manager screens
    /// </summary>
    /// <returns></returns>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="NullReferenceException"></exception>    
    public IEnumerable<BO.OrderForList> GetAll()
    {
        IEnumerable<DO.Order?> orders = dal.Order.GetAll() ?? throw new BO.BlDoesNotExistException("There is no orders to show!");
        List<BO.OrderForList> ordersList = new();
        foreach (var order in orders)
        {
            var orderItems = dal.OrderItem.GetAll(oi => oi?.OrderID == order?.ID) ?? throw new BO.BlInvalidFieldException("There is no order items to show!");
            ordersList.Add(
                new()
                {
                    ID = order?.ID ?? throw new NullReferenceException("Missing ID"),
                    CustomerID = order?.CustomerID ?? throw new NullReferenceException("Missing customer ID"),
                    Status = CalcStatus(order),
                    AmountOfItems = orderItems.Count(),
                    TotalPrice = orderItems.Sum(oi => oi?.Price * oi?.Amount) ?? throw new BO.BlFailedException("Failed to calculate order total price")
                });
        }
        return ordersList;
    }

    private BO.OrderStatus CalcStatus(DO.Order? order)
    {
        if (order?.DeliveryDate != null)
            return BO.OrderStatus.Delivered;
        else if (order?.ShipDate != null)
            return BO.OrderStatus.Shipped;
        else
            return BO.OrderStatus.Ordered;
    }
    #endregion

    #region Track Order
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BO.OrderTracking TrackOrder(int ID)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BO.Order Update(BO.Order order)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update Delivery
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BO.Order UpdateDelivery(int ID)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update Shipping
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BO.Order UpdateShipping(int ID)
    {
        throw new NotImplementedException();
    }
    #endregion
}




