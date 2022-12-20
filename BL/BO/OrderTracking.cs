namespace BO;

public class OrderTracking
{
    /// <summary>
    /// Order ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Pairs of order date and status
    /// </summary>
    public List<Tuple<DateTime?, string?>> Progress { set; get; } = new();

    public override string ToString() => $@"
    Order ID: {ID}
    Order Status: {Status}
    Progress: {Progress}
    ";
}
