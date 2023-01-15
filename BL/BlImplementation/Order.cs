using BlApi;

namespace BlImplementation;

internal class Order : IOrder
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
        CheckID(ID);

        try
        {
            DO.Order doOrder = dal.Order.GetById(ID);
            return BuildBoOrder(doOrder);
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Failed to get order", ex);
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
    /// <exception cref="BO.BlFailedException"></exception>    
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

    /// <summary>
    /// Calculate and returns order status
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private BO.OrderStatus CalcStatus(DO.Order? order)
    {
        if (order?.DeliveryDate != null)
            return BO.OrderStatus.Delivered;
        else if (order?.ShipDate != null)
            return BO.OrderStatus.Shipped;
        else if (order?.OrderDate != null)
            return BO.OrderStatus.Ordered;
        else
            throw new NullReferenceException("The order must have order date");
    }
    #endregion

    #region Track Order
    /// <summary>
    /// Create information of order tracking, for manager screen
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public BO.OrderTracking TrackOrder(int ID)
    {
        CheckID(ID);
        try
        {
            DO.Order doOrder = dal.Order.GetById(ID);
            BO.OrderTracking track = new()
            {
                ID = doOrder.ID,
                Status = CalcStatus(doOrder)
            };
            if (track.Status == BO.OrderStatus.Delivered)
            {
                track.Tracking.Add(new Tuple<DateTime, string>(doOrder.DeliveryDate!.Value, "Order delivered"));
            }
            else if (track.Status == BO.OrderStatus.Shipped)
            {
                track.Tracking.Add(new Tuple<DateTime, string>(doOrder.ShipDate!.Value, "Order shipped"));
            }
            else
            {
                track.Tracking.Add(new Tuple<DateTime, string>(doOrder.OrderDate, "Order created"));

            }
            return track;
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Failed to track order", ex);
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
    #endregion

    #region Update Delivery
    /// <summary>
    /// Update order delivery status
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlAlreadyExistsException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public BO.Order UpdateDelivery(int ID)
    {
        CheckID(ID);
        try
        {
            DO.Order doOrder = dal.Order.GetById(ID);
            //check if the order already shipped
            if (doOrder.ShipDate == null)
            {
                throw new BO.BlInvalidFieldException("The order not shipped yet!");
            }
            // check if the order does not delivered yet
            if (doOrder.DeliveryDate != null)
            {
                throw new BO.BlAlreadyExistsException("The order already delivered!");
            }
            doOrder.DeliveryDate = DateTime.Now;
            dal.Order.Update(doOrder);

            return BuildBoOrder(doOrder);
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Failed to update order delivery status", ex);
        }
    }
    #endregion

    #region Update Shipping
    /// <summary>
    /// Update order shipping status
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlAlreadyExistsException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    public BO.Order UpdateShipping(int ID)
    {
        CheckID(ID);
        try
        {
            DO.Order doOrder = dal.Order.GetById(ID);
            // check if the order does not shipped yet
            if (doOrder.ShipDate != null)
            {
                throw new BO.BlAlreadyExistsException("The order already shipped!");
            }
            doOrder.ShipDate = DateTime.Now;
            dal.Order.Update(doOrder);

            return BuildBoOrder(doOrder);
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Failed to update order shipping status", ex);
        }
    }

    /// <summary>
    /// Create BO order from DO order
    /// </summary>
    /// <param name="doOrder"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    private BO.Order BuildBoOrder(DO.Order? doOrder)
    {
        BO.Order boOrder = new()
        {
            ID = doOrder?.ID ?? throw new NullReferenceException("Missing ID"),
            CustomerID = doOrder?.CustomerID ?? throw new NullReferenceException("Missing customer ID"),
            OrderDate = doOrder?.OrderDate ?? throw new NullReferenceException("Missing order date"),
            ShipDate = doOrder?.ShipDate,
            DeliveryDate = doOrder?.DeliveryDate,
            Status = CalcStatus(doOrder),
            Items = from oi in dal.OrderItem.GetAll(oi => oi?.OrderID == doOrder?.ID)
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
    #endregion

    /// <summary>
    /// Check if order ID is legit
    /// </summary>
    /// <param name="ID"></param>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    private void CheckID(int ID)
    {
        if (ID < 1000000 || ID >= 5000000)
            throw new BO.BlInvalidFieldException("Order ID must be between 1000000 to 5000000");
    }
}




