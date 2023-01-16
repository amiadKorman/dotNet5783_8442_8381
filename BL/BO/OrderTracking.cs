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
    public OrderStatus? Status { get; set; }

    /// <summary>
    /// Pairs of order date and status
    /// </summary>
    public List<Tuple<DateTime?, string?>?>? Tracking { set; get; }

    public override string ToString() => $@"
        Order ID: {ID}
        Order Status: {Status}
        Tracking: 
                {String.Join("\n\t\t", Tracking ?? new List<Tuple<DateTime?, string?>?>())}
    ";
}
