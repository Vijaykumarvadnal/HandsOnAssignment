using System.Collections.Generic;
using HoA.Entity;

namespace HoA.Dal.Contracts
{
    public interface ICustomerDal : IBaseDal<Customer>
    {
        bool Insert(Customer customer);
        bool Update(Customer customer);
        IList<Customer> GetAll();
        Customer Get(Customer customer);
        bool Delete(Customer customer);
    }
}
