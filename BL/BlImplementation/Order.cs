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
    /// <exception cref="BO.BlDoesNotExistException"></exception>
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
                DeliveryDate = doOrder?.DeliveryDate ?? throw new NullReferenceException("Missing delivery date")
            };
            boOrder.Items = from order in dal.OrderItem.GetAll(oi => oi?.OrderID == ID)
                            select new BO.OrderItem
                            {
                                ID = order?.ID ?? throw new NullReferenceException("Missing ID"),
                                Price = order?.Price ?? throw new NullReferenceException("Missing price"),
                                Amount = order?.Amount ?? throw new NullReferenceException("Missing amount"),
                                ProductID = order?.ProductID ?? throw new NullReferenceException("Missing product ID"),
                                TotalPrice = order?.Amount * order?.Price ?? throw new NullReferenceException("Missing amount or price"),
                                Name = dal.Product.GetById(order?.ProductID ?? throw new NullReferenceException("Missing product ID")).Name
                            };
            return boOrder;
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        }
    }
    #endregion

    #region get All
    /// <summary>
    /// Get all orders details from store database, for manager screen
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>    
    public IEnumerable<BO.OrderForList> GetAll()
    {
        IEnumerable<DO.Order?> orders = dal.Order.GetAll() ?? throw new BO.BlDoesNotExistException("There is no orders to show!");
        List<BO.OrderForList> ordersList = new();
        foreach (var order in orders)
        {
            var orderItems = dal.OrderItem.GetAll(oi => oi?.OrderID == order?.ID) ?? throw new;
            ordersList.Add(
                new()
                {
                    ID = order?.ID ?? throw new NullReferenceException("Missing ID"),
                    CustomerID = order?.CustomerID ?? throw new NullReferenceException("Missing customer ID"),
                    Status = CalcStatus(order),
                    AmountOfItems = orderItems.Count(),
                    TotalPrice = orderItems.Sum(oi => oi?.Price * oi?.Amount)
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




