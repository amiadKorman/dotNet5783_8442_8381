﻿namespace BO;

/// <summary>
/// order class
/// </summary>
public class Order
{
    /// <summary>
    /// Unique order ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Customer ID
    /// </summary>
    public int CustomerID { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    public OrderStatus? Status { get; set; }

    /// <summary>
    /// Order date
    /// </summary>
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// Ship date
    /// </summary>
    public DateTime? ShipDate { get; set; }

    /// <summary>
    /// Delivery date 
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// Order items
    /// </summary>
    public List<OrderItem?>? Items { get; set; }

    /// <summary>
    /// Total order price
    /// </summary>
    public double TotalPrice { get; set; }

    public override string ToString() => $@"
        Order ID: {ID}
        Customer ID: {CustomerID}
        Status: {Status}
        Order Date: {OrderDate}
        Ship Date: {ShipDate}
        Delivery Date: {DeliveryDate}
        Items: 
                {String.Join("\n\t\t", Items ?? new List<OrderItem?>())}
        Total Price: {TotalPrice}
    ";
}
