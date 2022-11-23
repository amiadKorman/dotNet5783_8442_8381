using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalCustomer : ICustomer
{
    #region ADD
    /// <summary>
    /// Add new customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>new customer ID</returns>
    /// <exception cref="Exception"></exception>
    public int Add(Customer customer)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == customer.ID);
        if (index != -1)
            throw new Exception("Customer ID already exist");

        customersArray[customersLastIndex++] = new()
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
    public Customer GetById(int id)
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
    public IEnumerable<Customer?> GetAll(Func<Customer?, bool>? filter)
    {
        Customer[] customer = new Customer[customersLastIndex];
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
    public void Update(Customer customer)
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
    public void Delete(int id)
    {
        int index = Array.FindIndex(customersArray, c => c.ID == customerID);
        if (index == -1)
            throw new Exception("Customer ID doesn't exist");

        customersArray = customersArray.Where((e, i) => i != index).ToArray();
        customersLastIndex--;
        return;
    }
    #endregion
}
