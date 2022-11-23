﻿using DO;
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
    /// <returns> customer ID </returns>
    /// <exception cref="DalAlreadyExistsException"></exception>
    public int Add(Customer customer)
    {
        if (customers.FirstOrDefault(c => c?.ID == customer.ID) != null)
            throw new DalAlreadyExistsException($"Customer with ID={customer.ID} already exists");
        customers.Add(customer);
        return customer.ID;
    }
    #endregion

    #region GET
    /// <summary>
    /// Return customer by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> customer </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public Customer GetById(int id) => customers.FirstOrDefault(c => c?.ID == id) ?? throw new DalDoesNotExistException("Customer ID doesn't exist");

    /// <summary>
    /// Return all customers in DataSource by filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns> filtered list of customers </returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public IEnumerable<Customer?> GetAll(Func<Customer?, bool>? filter) =>
        (filter == null ?
            customers.Select(customer => customer) :
            customers.Where(filter))
        ?? throw new DalDoesNotExistException("Missing customers");
    #endregion

    #region UPDATE
    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="customer"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Update(Customer customer)
    {
        int index = customers.FindIndex(c => c?.ID == customer.ID);
        if (index == -1)
            throw new DalDoesNotExistException($"Customer item with ID={customer.ID} doesn't exists");

        customers[index] = customer;
    }
    #endregion

    #region DELETE
    /// <summary>
    /// Delete customer by given ID
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        if (customers.RemoveAll(c => c?.ID == id) == 0)
            throw new DalDoesNotExistException("Can't delete, customer ID doesn't exist");
    }
    #endregion
}
