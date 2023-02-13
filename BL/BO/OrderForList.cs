namespace BO;

/// <summary>
/// Order class for list view 
/// </summary>
public class OrderForList
{
    /// <summary>
    /// Unique order ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Customer ID
    /// </summary>
    public int CustomerID { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    public OrderStatus? Status { get; set; }

    /// <summary>
    /// Amount of items in order
    /// </summary>
    public int AmountOfItems { get; set; }

    /// <summary>
    /// Total price of the order
    /// </summary>
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
    Order ID: {ID}
    Customer ID: {CustomerID}
    Order Status: {Status}
    Amount Of Items: {AmountOfItems}
    Total Price: {TotalPrice}
    ";
}
