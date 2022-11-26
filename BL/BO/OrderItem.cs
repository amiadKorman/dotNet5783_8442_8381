namespace BO;

public class OrderItem
{
    /// <summary>
    /// ID of the order item
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// ID of the product
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Name of product
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Price of the product
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Amount of product in the order
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Products total price
    /// </summary>
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
        Order Item ID: {ID}
        Product ID: {ProductID} 
        Product Name: {Name}
        Product Price: {Price}
        Amount: {Amount}
        Total Price: {TotalPrice}
    ";
}
