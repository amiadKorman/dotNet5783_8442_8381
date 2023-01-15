using System.ComponentModel;

namespace BlTest;

#region Entitys's menu 
/// <summary>
/// Enums for the Main program
/// </summary>
public enum EnumsEntitysMenu
{
    [Description("Get to Order menu")]
    OrderMenu = 1,
    [Description("Get to Cart menu")]
    CartMenu = 2,
    [Description("Get to Product menu")]
    ProductMenu = 3,
    [Description("Exit from program")]
    Exit = 0,
}
#endregion

#region Order Menu
/// <summary>
/// Enus for the Menu of the Order menu
/// </summary>
public enum EnumsOrderMenu
{
    [Description("Show Orders List")]
    ShowListOfOrders = 1,
    [Description("Show Order Details")]
    ShowOrderDetails = 2,
    [Description("Update Order Shipping")]
    UpdateOrderShipping = 3,
    [Description("Update Order Delivery")]
    UpdateOrderDelivery = 4,
    [Description("Order Tracking")]
    TrackOrder = 5,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion

#region Cart Menu
/// <summary>
/// Enums for the Menu of the Cart menu
/// </summary>
public enum EnumCartMenu
{
    [Description("Log In")]
    LogIn = 1,
    [Description("Add Product to Cart")]
    AddProductToCart = 2,
    [Description("Update Product Amount")]
    UpdateProductAmount = 3,
    [Description("Buy Cart")]
    BuyCart = 4,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion

#region Product Menu
/// <summary>
/// Enums for the Menu of the Product menu
/// </summary>
public enum EnumsProductMenu
{
    [Description("Show Products List")]
    ShowListOfProducts = 1,
    [Description("Show Products Catalog")]
    ShowProductCatalog = 2,
    [Description("Show Product Details(manager)")]
    ShowProductManager = 3,
    [Description("Show Product Details(buyer)")]
    ShowProductBuyer = 4,
    [Description("Add a Product")]
    AddProduct = 5,
    [Description("Delete a Product")]
    DeleteProduct = 6,
    [Description("Update Product Details")]
    UpdateProduct = 7,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion
