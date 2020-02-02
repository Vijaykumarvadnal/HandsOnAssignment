using System.Collections.Generic;
using HoA.Entity;

namespace HoA.Service.Contracts
{
    public interface ICustomerService
    {
        bool Insert(Customer customer);
        bool Update(Customer customer);
        IList<Customer> GetAll();
        Customer Get(Customer customer);
        bool Delete(Customer customer);
    }
}
