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
        /// <summary>
        /// Create a new Entity.
        /// </summary>
        public static void AddEntity()
        {
            
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
                case Dal.Menu.Exit:
                    break;
                default:
                    Console.WriteLine("Error. Try again");
                    break;
            }

            

        }

        
    }



    }
}


