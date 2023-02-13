namespace BO;

/// <summary>
/// Product class 
/// </summary>
public class Product
{
    /// <summary>
    /// Product ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string? Name { get; set; }

    /// <summary> 
    /// Product price
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Product category
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// Amount in stock of the product
    /// </summary>
    public int InStock { get; set; }

    public override string ToString() => $@"
        Product ID: {ID}
        Name: {Name}
        Category: {Category}
    	Price: {Price}
    	Amount in stock: {InStock}
    ";
}
