using System.ComponentModel;

namespace BO;

public enum Category
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
    [Description("Initiated")]
    Initiated = 1,
    [Description("Ordered")]
    Ordered,
    [Description("Paid")]
    Paid,
    [Description("Shipped")]
    Shipped,
    [Description("Delivered")]
    Delivered,
}
