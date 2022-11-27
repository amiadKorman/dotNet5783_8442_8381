namespace BO;

public class Cart
{
    /// <summary>
    /// Cart customer ID
    /// </summary>
    public int CustomerID { get; set; }

    /// <summary>
    /// Order items in the cart
    /// </summary>
    public IEnumerable<OrderItem>? Items { get; set; }

    /// <summary>
    /// Total price of the cart
    /// </summary>
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
        Customer ID: {CustomerID}
        Items: {Items}
        Total Price: {TotalPrice}
    ";
}
