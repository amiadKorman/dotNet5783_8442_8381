using DO;
using static Dal.DataSource;

namespace Dal;

public class DalCustomer
{
    #region ADD
    /// <summary>
    /// Add new customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>new customer ID</returns>
    /// <exception cref="Exception"></exception>
    public int AddCustomer(Customer customer)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == customer.ID);
        if (index != -1)
            throw new Exception("Customer ID already exist");

        customersArray[Config.customersLastIndex++] = new()
        {
            ID = customer.ID,
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address
        };
        return customer.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return customer by given ID
    /// </summary>
    /// <param name="customerID"></param>
    /// <returns>customer</returns>
    /// <exception cref="Exception"></exception>
    public Customer GetCustomer(int customerID)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == customerID);
        if (index == -1)
            throw new Exception("Customer ID doesn't exist");

        return customersArray[index];
    }

    /// <summary>
    /// Return all the customers in the DataSource
    /// </summary>
    /// <returns>customer array</returns>
    public Customer[] GetAllCostomers()
    {
        Customer[] customer = new Customer[Config.customersLastIndex];
        Array.Copy(customersArray, customer, customer.Length);
        return customer;
    }
    #endregion

    #region UPDATE
    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="newCustomer"></param>
    /// <exception cref="Exception"></exception>
    public void UpdateCustomer(Customer newCustomer)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == newCustomer.ID);
        if (index == -1)
            throw new Exception("Customer ID doesn't exist");

        customersArray[index] = newCustomer;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete customer by given ID
    /// </summary>
    /// <param name="customerID"></param>
    /// <exception cref="Exception"></exception>
    public void DeleteCustomer(int customerID)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == customerID);
        if (index == -1)
            throw new Exception("Customer ID doesn't exist");

        customersArray = customersArray.Where((e, i) => i != index).ToArray();
        Config.customersLastIndex--;
        return;
    }
    #endregion
}
