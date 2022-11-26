using System.ComponentModel;

namespace BO;

public enum CategoryOfProduct
{
    [Description("Phones")]
    Phones = 1,
    [Description("Laptops")]
    Laptops = 2,
    [Description("Screens")]
    Screens = 3,
    [Description("Televisions")]
    Televisions = 4,
    [Description("Accessories")]
    Accessories = 5,
}

public enum OrderStatus
{
    [Description("Approved")]
    Approved = 1,
    [Description("Shipped")]
    Shipped = 2,
    [Description("Delivered")]
    Delivered = 3
}
