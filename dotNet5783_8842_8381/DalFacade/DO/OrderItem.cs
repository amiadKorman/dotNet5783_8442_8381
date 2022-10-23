
namespace DO;

/// <summary>
/// Strucure for OrderItems
/// </summary>
public struct OrderItem
{
    /// <summary>
    /// ID of procuct
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Name of OrderName
    /// </summary>
    public int OrderName { get; set; }

    /// <summary>
    /// Praice of the order
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Amount of product in the order
    /// </summary>
    public int Amount { get; set; }

    public override string ToString() => $@"
        Product ID: {ProductId}, 
        Order Name: {OrderName}
        Price: {Price}
        Amount: {Amount}
    ";

}
