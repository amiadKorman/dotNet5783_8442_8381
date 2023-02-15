using BO;
using System.Collections;

namespace BlApi;

public interface ICustomer
{
    IEnumerable<Customer?> GetList();
}

