using System.ComponentModel;

namespace Dal;

#region Entitys's menu
public enum EntitysMenu
{
    [Description("Exit from program")]
    Exit = 0,
    [Description("Get to Order's menu")]
    OrderMenu = 1,
    [Description("Get to OrderItems's menu")]
    OrderItemsMenu = 2,
    [Description("Get to Product's menu")]
    ProductMenu = 3,
}
#endregion

#region Order Menu
public enum OrderMenu  
{
    [Description("Add an Order")]
    AddOrder = 1,
    [Description("Update an Order")]
    UpdateOrder = 2,
    [Description("Show an Order")]
    ShowOrder = 3,
    [Description("Show an Order List")]
    ShowListOfOrder = 4,
    [Description("Delete an Order")]
    DeleteAnOrder = 5,
    [Description("Return back to the menu")]
    GoToTheFirstMenu = 9

}
#endregion

#region Order Item Menu
public enum OrderItemMenu
{
    [Description("Add an Order Items")]
    AddOrderItems = 1,
    [Description("Update an Order Items")]
    UpdateOrderItems = 2,
    [Description("Show an Order Items")]
    ShowOrderItems = 3,
    [Description("Show an Order Items List")]
    ShowListOfOrderItems = 4,
    [Description("Delete an Order Items List")]
    DeleteAnOrderItems = 5,
    [Description("Return back to the menu")]
    GoToTheFirstMenu = 9
}
#endregion

#region Product Menu
public enum ProductMenu
{
    [Description("Add a Product")]
    AddProduct = 1,
    [Description("Update a Product")]
    UpdateProduct = 2,
    [Description("Show a Product")]
    ShowProduct = 3,
    [Description("Show a Product List")]
    ShowListOfProduct = 4,
    [Description("Delete a Product List")]
    DeleteAProduct = 5,
    [Description("Return back to the menu")]
    GoToTheFirstMenu = 9
}
#endregion       
