using BlApi;
using BO;
using System.Collections;

namespace BlImplementation
{
    internal class Customer : ICustomer
    {
        private readonly DalApi.IDal dal = DalApi.Factory.Get()!;

        public IEnumerable<BO.Customer?> GetList()
        {
            IEnumerable<BO.Customer?> list = from customer in dal.Customer.GetAll()
                       select new BO.Customer
                       {
                           ID = customer?.ID,
                           Name = customer?.Name,
                           Email = customer?.Email,
                           Address = customer?.Address
                       };

            return list;
        }
    }
    
}
