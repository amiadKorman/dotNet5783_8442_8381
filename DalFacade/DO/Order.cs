
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
    public int CustomerId { get; set; }

  
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

    public override string ToString() => $@"
        Order ID: {ID}, 
        Customer Name: {CustomerId},
        Order Date: {OrderDate},
        Ship Date: {ShipDate},
        Delivery Date: {DeliveryDate},
    ";

}