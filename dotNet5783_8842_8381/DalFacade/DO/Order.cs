using System.ComponentModel;
using static DO.Enums;

namespace DO;

/// <summary>
/// Strucure for Order
/// </summary>
public struct Order
{
    /// <summary>
    /// Unique order ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Customer name
    /// </summary>
    public string CustomerName { get; set; }
    /// <summary>
    /// Customer email
    /// </summary>
    public string CustomerEmail { get; set; }
    /// <summary>
    /// Customer address
    /// </summary>
    public string CustomerAdressl { get; set; }
    /// <summary>
    /// Order date
    /// </summary>
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// Ship date
    /// </summary>
    public DateTime ShipDate { get; set; }
    /// <summary>
    /// Delivery date
    /// </summary>
    public DateTime DeliveryDate { get; set; }
}