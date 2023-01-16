using BO;

namespace BlApi;

public interface IOrder
{
    /// <summary>
    /// Returns list of all orders, for manager
    /// </summary>
    /// <returns> List of orders </returns>
    public IEnumerable<OrderForList?> GetAll();
    
    /// <summary>
    /// Get order details, for manager and buyer
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Order Get(int ID);
    
    /// <summary>
    /// Update shipping date, for manager
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Order UpdateShipping(int ID);
    
    /// <summary>
    /// Update delivery tome, for manager
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Order UpdateDelivery(int ID);
    
    /// <summary>
    /// Return order tracking information, for manager
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public OrderTracking TrackOrder(int ID);
    
    /// <summary>
    /// Update order details, for manager (optional bonus)
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public Order Update(Order order);
}
