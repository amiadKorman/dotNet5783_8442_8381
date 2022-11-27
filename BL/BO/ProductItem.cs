namespace BO;

/// <summary>
/// This class serves presentation of a product in Catalogue product list (for a buyer)
/// </summary>
public class ProductItem
{
    /// <summary>
    /// Product ID number
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Product name / short description
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Current product price
    /// </summary>
    public double Price { get; set; }
    /// <summary>
    /// Product category
    /// </summary>
    public Category Category { get; set; }
    /// <summary>
    /// Shows whether the product is in stock
    /// </summary>
    public bool InStock { get; set; }
    /// <summary>
    /// Amount of product in cart
    /// </summary>
    public int Amount { get; set; }

    public override string ToString() => $@"
        Product ID: {ID}
        Name: {Name}
        Category: {Category}
    	Price: {Price}
        Amount: {Amount}
    	In stock: {(InStock ? "yes" : "no")}
    ";
}
