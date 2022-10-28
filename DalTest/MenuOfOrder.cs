﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MenuOfOrder
    {
        #region Add New Order
        public static void AddNewOrder()
        {
            Order NewOrder = new Order();
            Console.WriteLine("for add a new Order, please fill in the following data:");


            NewOrder.ID = SafeInput.IntegerInput("ID: ");            
            NewOrder.CustomerName = SafeInput.stringInput("Name: ");            
            NewOrder.CustomerEmail = SafeInput.stringInput("Email: ");
            NewOrder.CustomerEmail = SafeInput.stringInput("Adress:");         

            DateTime? NullDateTime = null;
            NewOrder.OrderDate = Convert.ToDateTime(NullDateTime);
            NewOrder.ShipDate = Convert.ToDateTime(NullDateTime); ;
            NewOrder.DeliveryDate = Convert.ToDateTime(NullDateTime);

            Console.WriteLine("Adding a new Base Station...");
            
            ///צריך "לשמור את הישות פה"

            Console.WriteLine("The new Base Station was successfully added\n");

        }
        #endregion

        #region Update Order
        public static void UpdateOrder()
        {


        }
        #endregion

        #region Show Order
        public static void ShowOrder()
        {
            int IdOrder = SafeInput.IntegerInput("ID: ");
            //Console.WriteLine(DalOrder(IdOrder));

        }

        #endregion

        #region Show Order List
        public static void ShowOrderList()
        {
            

        }
        #endregion

        #region Delete Order
        public static void DeleteOrder()
        {

        }
        #endregion

        #region OrderMenu
        public static void OrderMenu()
        {
            Dal.OrderMenu Orderchoise = Dal.OrderMenu.AddOrder;
            while (!Orderchoise.Equals(Dal.EntitysMenu.Exit))
            {
                Console.WriteLine("for add Order - press 1\n" +
            "for Update Order - press 2\n" +
            "for show order - press 3\n" +
            "for show order list - press 4\n" +
            "for delete order - press 5\n");
            }                          
            switch (Orderchoise)
            {
                case Dal.OrderMenu.AddOrder:
                    AddNewOrder();
                    break;
                case Dal.OrderMenu.UpdateOrder:
                    UpdateOrder();
                    break;
                case Dal.OrderMenu.ShowOrder:
                    ShowOrder();
                    break;
                case Dal.OrderMenu.ShowListOfOrder:
                    ShowOrderList();
                    break;
                case Dal.OrderMenu.DeleteAnOrder:
                    DeleteOrder();
                    break;                
                default:
                    Console.WriteLine("This option does not exist, please try again\n");
                    break;
            }
        }
        #endregion
    }
}
