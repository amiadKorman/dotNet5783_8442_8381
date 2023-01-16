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
    public List<OrderItem?>? Items { get; set; } = new();

    /// <summary>
    /// Total price of the cart
    /// </summary>
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
        Customer ID: {CustomerID}
        Items: 
                {String.Join("\n\t\t", Items)}
        Total Price: {TotalPrice}
    ";
}
