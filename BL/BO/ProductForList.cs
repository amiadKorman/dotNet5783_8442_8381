namespace BO;

public class ProductForList
{
    /// <summary>
    /// Product ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; }

    /// <summary> 
    /// Product price
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Product category
    /// </summary>
    public CategoryOfProduct Category { get; set; }

    public override string ToString() => $@"
        Product ID: {ID}
        Name: {Name}
        Category: {Category}
    	Price: {Price}
    ";
}
