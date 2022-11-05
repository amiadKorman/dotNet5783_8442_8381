namespace DO;

public struct Customer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public int CustomerID { get; set; }

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
    public string CustomerAddress { get; set; }

    public override string ToString() => $@"
        Customer ID: {CustomerID}, 
        Customer Name: {CustomerName},
        Customer Email: {CustomerEmail},
        Customer Adress: {CustomerAddress}";  
}
