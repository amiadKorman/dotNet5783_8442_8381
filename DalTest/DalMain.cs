using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class DalMain
    {

        #region Add Entity
        
        public static void AddNewOrder()
        {
            Order NewOrder = new Order();
            Console.WriteLine("for add a new Order, please fill in the following data:");

            NewOrder.ID = SafeInput.IntegerInput("ID: ");

            Console.WriteLine("Name: ");
            NewOrder.CustomerName = Console.ReadLine();
            Console.WriteLine("Email: ");
            NewOrder.CustomerEmail = Console.ReadLine();
            Console.WriteLine("Adress: ");
            NewOrder.CustomerEmail = Console.ReadLine();
            Console.WriteLine("Adress: ");

            Console.WriteLine("Adding a new Base Station...");
            

            Console.WriteLine("The new Base Station was successfully added\n");








        }


        public static void AddNewOrderItem()
        {

        }


        public static void AddNewProduct()
        {

        }



        public static void AddEntity()
        {
            // <summary>
            /// Add a new entity for the list.
            /// </summary>
            /// <param name="choise"></param>
            public static void AddEntity()
            {
                Add AddChoise = (Add)SafeInput.IntegerInput
                (
                    "for add Base station to Stations list - press 1\n" +
                    "for add Drone to the Drones list - press 2\n" +
                    "for add Customer to the Customers list - press 3\n" +
                    "for add new Parcel to Parcels list - press 4\n"
                );
                switch (AddChoise)
                {
                    case Add.AddOrder:
                        AddNewOrder();
                        break;
                    case Add.AddOrderItems:
                        AddNewOrderItem();
                        break;
                    case Add.Product:
                        AddNewProduct();
                        break;                   
                    default:
                        Console.WriteLine("This option does not exist, please try again\n");
                        break;
                }
            }
        }

        #endregion

        #region Show Entity
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void ShowEntity()
        {

        }
        #endregion

        #region Show List Of Entity
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void ShowListOfEntity()
        {

        }
        #endregion

        #region Update Entity
        /// <summary>
        /// 
        /// </summary>
        public static void UpdateEntity()
        {

        }
        #endregion


        #region Delete Entitys
        /// <summary>
        /// 
        /// </summary>
        public static void DeleteEntitys()
        {

        }
        #endregion



        #region Mainaly Main
        static void Main(string[] args)
            {
                Dal.Menu MenuChoise = Dal.Menu.AddEntity;
                while (!MenuChoise.Equals(Dal.Menu.Exit))
                {
                    Console.WriteLine("For Order press 1\n" +
                    "For OrderItem press 2\n" +
                    "For product press 3\n" +
                    "Foe Exit press 5");
                };
            switch (MenuChoise)
            {
                case Dal.Menu.AddEntity:
                    AddEntity();
                    break;                
                case Dal.Menu.ShowByID:
                    ShowEntity();
                    break;
                case Dal.Menu.ShowListOfEntity:
                    ShowListOfEntity();
                    break;
                case Dal.Menu.UpdateEntity:
                    UpdateEntity();
                    break;
                case Dal.Menu.DeleteEntitys:
                    DeleteEntitys();
                    break;
                case Dal.Menu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }

            

        }
        #endregion

    }



}
}


