﻿using DalApi;
using DO;

namespace Dal;

internal class MenuOfCustomer
{
    private static readonly IDal dal = Factory.Get()!;

    #region ADD
    /// <summary>
    /// Add new customer
    /// </summary>
    public static void AddNewCustomer()
    {
        Console.WriteLine("To add a new customer, please fill in the following data:");

        int ID = SafeInput.IntegerInput("ID: ");
        string name = SafeInput.StringInput("Name: ");
        string email = SafeInput.StringInput("Email: ");
        string address = SafeInput.StringInput("Address: ");
        Console.WriteLine("Adding a new Product...");
        Customer customer = new()
        {
            ID = ID,
            Name = name,
            Email = email,
            Address = address
        };
        try
        {
            int customerID = dal.Customer.Add(customer);
            Console.WriteLine($"The new customer was successfully added with ID {customerID}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update existing customer
    /// </summary>
    public static void UpdateCustomer()
    {
        int IDCustomer = SafeInput.IntegerInput("Enter customer ID to update: ");
        try
        {
            Customer customer = dal.Customer.Get(IDCustomer);
            Console.WriteLine(customer);
            Console.WriteLine("To update, please fill in the following data(leave empty for no update):");
            // User input for product properties
            string email = SafeInput.NullStringInput("Email: ");
            string address = SafeInput.NullStringInput("Address: ");
            // Checking for changes to update
            if (email != "")
                customer.Email = email;
            if (address != "")
                customer.Address = address;

            dal.Customer.Update(customer);
            Console.WriteLine($"The customer was successfully updated:\n" + customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region SHOW
    /// <summary>
    /// Print specific customer
    /// </summary>
    public static void ShowCustomer()
    {
        int IDCustomer = SafeInput.IntegerInput("Enter customer ID to show: ");
        try
        {
            Customer customer = dal.Customer.Get(IDCustomer);
            Console.WriteLine(customer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }

    /// <summary>
    /// Print all customers
    /// </summary>
    public static void ShowListCustomer()
    {
        IEnumerable<Customer?> customers = dal.Customer.GetAll();
        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete customer by ID
    /// </summary>
    public static void DeleteCustomer()
    {
        int IDCustomer = SafeInput.IntegerInput("Enter customer ID to delete: ");
        try
        {
            dal.Customer.Delete(IDCustomer);
            Console.WriteLine("The customer was successfully deleted\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ", please try again\n");
        }
    }
    #endregion

    #region MENU
    /// <summary>
    /// Print customer menu and calls the appropriate method
    /// </summary>
    public static void CustomerMenu()
    {
        CustomerMenu ProductChoise = Dal.CustomerMenu.AddCustomer;
        while (!ProductChoise.Equals(Dal.CustomerMenu.GoBack))
        {
            ProductChoise = (CustomerMenu)SafeInput.IntegerInput(
                "To Add a Customer - press 1\n" +
                "To Update a Customer - press 2\n" +
                "To Show a Customer - press 3\n" +
                "To Show Customers List - press 4\n" +
                "To Delete a Customer - press 5\n" +
                "To Return back to the menu - press 0\n\n");

            switch (ProductChoise)
            {
                case Dal.CustomerMenu.AddCustomer:
                    AddNewCustomer();
                    break;
                case Dal.CustomerMenu.UpdateCustomer:
                    UpdateCustomer();
                    break;
                case Dal.CustomerMenu.ShowCustomer:
                    ShowCustomer();
                    break;
                case Dal.CustomerMenu.ShowListOfCustomers:
                    ShowListCustomer();
                    break;
                case Dal.CustomerMenu.DeleteCustomer:
                    DeleteCustomer();
                    break;
                case Dal.CustomerMenu.GoBack:
                    break;
                default:
                    Console.WriteLine("This option doesn't exist, please try again\n");
                    break;
            }
        }
    }
    #endregion
}