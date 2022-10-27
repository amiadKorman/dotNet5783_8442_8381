using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    #region Enums Menu
    public enum Menu
    {
        [Description("Add an entity")]
        AddEntity = 1,
        [Description("Show by ID an entity")]
        ShowByID = 2,
        [Description("Show list of an entitys")]
        ShowListOfEntity = 3,
        [Description("Update an entitys")]
        UpdateEntity = 4,
        [Description("Delete an entitys")]
        DeleteEntitys = 5,
        [Description("Exit program")]
        Exit = 6
    }
    #endregion

    #region Add entity
    public enum Add
    {
        [Description("Add an Order")]
        AddOrder = 1,
        [Description("Add an Order Items")]
        AddOrderItems = 2,
        [Description("Add a Product")]
        Product = 3,
    }
    #endregion

    #region Show entity
    public enum ShowEntity
    {
        [Description("Show an Order")]
        ShowOrder = 1,
        [Description("Show an Order Items")]
        ShowOrderItems = 2,
        [Description("Show a Product")]
        ShowProduct = 3,
    }

    #endregion

    #region Show List of entity
    public enum ShowListOfEntity
    {
        [Description("Show an Order List")]
        ShowListOfOrder = 1,
        [Description("Show an Order Items List")]
        ShowListOfOrderItems = 2,
        [Description("Show a Product List")]
        ShowListOfProduct = 3,

    }
    #endregion

    #region Delete entity
    public enum DeleteEntity
    {
        [Description("Delete an Order")]
        DeleteAnOrder = 1,
        [Description("Delete an Order Items List")]
        DeleteAnOrderItems = 2,
        [Description("Delete a Product List")]
        DeleteAProduct = 3,
    }

    #endregion

}
