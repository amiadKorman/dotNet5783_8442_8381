﻿namespace DO;

/// <summary>
/// Strucure for OrderItems
/// </summary>
public struct OrderItem
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
    /// ID of the order
    /// </summary>
    public int OrderID { get; set; }

    /// <summary>
    /// Price of the order
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Amount of product in the order
    /// </summary>
    public int Amount { get; set; }

    public override string ToString() => $@"
        Order Item ID: {ID}
        Product ID: {ProductID} 
        Order ID: {OrderID}
        Price: {Price}
        Amount: {Amount}
    ";

}
