namespace BO;

public class ProductItem
{
    /// <summary>
    /// Product item ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Product item name
    /// </summary>
    public string Name { get; set; }

    /// <summary> 
    /// Product item price
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Product item category
    /// </summary>
    public CategoryOfProduct Category { get; set; }

    /// <summary>
    /// Amount of product items in cart
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Is product item in stock
    /// </summary>
    public bool InStock { get; set; }

    public override string ToString() => $@"
        Product ID: {ID}
        Name: {Name}
        Category: {Category}
    	Price: {Price}
        Amount: {Amount}
    	In stock: {(InStock ? "yes" : "no")}
    ";
}
