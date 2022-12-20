using BlApi;
using System.Collections.Generic;

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
    /// <exception cref="BO.BlFailedExceptiom"></exception>
    public BO.Order Get(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");

        try
        {
            DO.Order order = dal.Order.GetById(ID);
            return BuildBoOrder(order);
        }
        catch (Exception ex)
        {
            throw new BO.BlFailedExceptiom("Failed to get order details", ex);
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
                    TotalPrice = orderItems.Sum(oi => oi?.Price * oi?.Amount) ?? throw new BO.BlFailedExceptiom("Failed to calculate order total price")
                });
        }
        return ordersList;
    }
    #endregion

    #region Track Order
    /// <summary>
    /// Return order tracking information, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlFailedExceptiom"></exception>
    public BO.OrderTracking TrackOrder(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");

        try
        {
            DO.Order order = dal.Order.GetById(ID);
            return new BO.OrderTracking
            {
                ID = order.ID,
                Status = CalcStatus(order),
                Progress = CalcProgress(order)
            };
        }
        catch (Exception ex)
        {
            throw new BO.BlFailedExceptiom("Failed to track order", ex);
        }
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

    /// <summary>
    /// Update shipment time, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlFailedExceptiom"></exception>
    public BO.Order UpdateShipping(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");

        try
        {
            DO.Order order = dal.Order.GetById(ID);
            if (order.ShipDate != null)
                throw new BO.BlInvalidFieldException("Order already shipped!");

            order.ShipDate = DateTime.Now;
            dal.Order.Update(order);
            return BuildBoOrder(order);
        }
        catch (Exception ex)
        {
            throw new BO.BlFailedExceptiom("Failed to update order shipping", ex);
        }
    }

    /// <summary>
    /// Update delivery time, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlFailedExceptiom"></exception>
    public BO.Order UpdateDelivery(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");

        try
        {
            DO.Order order = dal.Order.GetById(ID);
            if (order.DeliveryDate != null)
                throw new BO.BlInvalidFieldException("Order already delivered!");
            else if (order.ShipDate == null)
                throw new BO.BlInvalidFieldException("Order must be shipped before delivered!");

            order.DeliveryDate = DateTime.Now;
            dal.Order.Update(order);
            return BuildBoOrder(order);
        }
        catch (Exception ex)
        {
            throw new BO.BlFailedExceptiom("Failed to update order delivery", ex);
        }
    }
    #endregion

    #region Help Methods
    /// <summary>
    /// Build BO Order entity from DO Order entity
    /// </summary>
    /// <param name="doOrder"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    private BO.Order BuildBoOrder(DO.Order doOrder)
    {
        BO.Order boOrder = new()
        {
            ID = doOrder.ID,
            CustomerID = doOrder.CustomerID,
            OrderDate = doOrder.OrderDate,
            ShipDate = doOrder.ShipDate,
            DeliveryDate = doOrder.DeliveryDate,
            Status = CalcStatus(doOrder)
        };

        IEnumerable<DO.OrderItem?> items = dal.OrderItem.GetAll(oi => oi?.OrderID == boOrder.ID);
        foreach (var oi in items)
        {
            boOrder.Items?.Add(new BO.OrderItem
            {
                ID = oi?.ID ?? throw new NullReferenceException("Missing ID"),
                Price = oi?.Price ?? throw new NullReferenceException("Missing price"),
                Amount = oi?.Amount ?? throw new NullReferenceException("Missing amount"),
                ProductID = oi?.ProductID ?? throw new NullReferenceException("Missing product ID"),
                TotalPrice = oi?.Amount * oi?.Price ?? throw new NullReferenceException("Missing amount or price"),
                Name = dal.Product.GetById(oi?.ProductID ?? throw new NullReferenceException("Missing product ID")).Name
            });
        }
        return boOrder;
    }

    /// <summary>
    /// Calculate order shipment status
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private BO.OrderStatus CalcStatus(DO.Order? order)
    {
        if (order?.DeliveryDate != null)
            return BO.OrderStatus.Delivered;
        else if (order?.ShipDate != null)
            return BO.OrderStatus.Shipped;
        else
            return BO.OrderStatus.Ordered;
    }

    /// <summary>
    /// Calculate order progress
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private List<Tuple<DateTime?, string?>> CalcProgress(DO.Order order)
    {
        List<Tuple<DateTime?, string?>> progress = new();
        if (order.OrderDate != null)
        {
            progress.Add(new(order.OrderDate, "Order created"));
        }
        if (order.ShipDate != null)
        {
            progress.Add(new(order.ShipDate, "Order shipped"));
        }
        if (order.DeliveryDate != null)
        {
            progress.Add(new(order.DeliveryDate, "Order delivered"));
        }
        return progress;
    }
    #endregion
}




