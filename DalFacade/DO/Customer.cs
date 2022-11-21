namespace DO;

public struct Customer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Customer email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Customer address
    /// </summary>
    public string Address { get; set; }

    public override string ToString() => $@"
        Customer ID: {ID}
        Name: {Name}
        Email: {Email}
        Address: {Address} 
    ";
}
