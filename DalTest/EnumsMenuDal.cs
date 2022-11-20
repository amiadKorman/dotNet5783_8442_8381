using System.ComponentModel;

namespace Dal;

#region Entitys's menu
public enum EntitysMenu
{
    [Description("Get to Order menu")]
    OrderMenu = 1,
    [Description("Get to OrderItem menu")]
    OrderItemsMenu = 2,
    [Description("Get to Product menu")]
    ProductMenu = 3,
    [Description("Get to Customer menu")]
    CustomerMenu = 4,
    [Description("Exit from program")]
    Exit = 0,
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
    [Description("Show Orders List")]
    ShowListOfOrder = 4,
    [Description("Delete an Order")]
    DeleteAnOrder = 5,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion

#region Order Item Menu
public enum OrderItemMenu
{
    [Description("Add an Order item")]
    AddOrderItems = 1,
    [Description("Update an Order item")]
    UpdateOrderItems = 2,
    [Description("Show an Order item by ID")]
    ShowOrderItemByID = 3,
    [Description("Show an Order item by order and product ID's")]
    ShowOrderItemByProductAndCustomerID = 4,
    [Description("Show Order items list")]
    ShowListOfOrderItems = 5,
    [Description("Show an specific Order's order items list")]
    ShowOrderItemsListOfSpecificOrder = 6,
    [Description("Delete an Order item")]
    DeleteAnOrderItems = 7,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
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
    [Description("Show Products List")]
    ShowListOfProduct = 4,
    [Description("Delete a Product")]
    DeleteAProduct = 5,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion     

#region Customer Menu
public enum CustomerMenu
{
    [Description("Add an Customer")]
    AddCustomer = 1,
    [Description("Update an Customer")]
    UpdateCustomer = 2,
    [Description("Show an Customer")]
    ShowCustomer = 3,
    [Description("Show Customers List")]
    ShowListOfCustomers = 4,
    [Description("Delete an Customer")]
    DeleteCustomer = 5,
    [Description("To Return Back To The Main Menu")]
    GoBack = 0
}
#endregion       

public enum YseOrNo
{
    [Description("No")]
    No = 1,
    [Description("Yes")]
    Yes = 2,
}