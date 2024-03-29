﻿namespace BO;

/// <summary>
/// Cart class for list of products in cart 
/// </summary>
public class ProductForList
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

    public override string ToString() => $@"
        Product ID: {ID}
        Name: {Name}
        Category: {Category}
    	Price: {Price}";
}
