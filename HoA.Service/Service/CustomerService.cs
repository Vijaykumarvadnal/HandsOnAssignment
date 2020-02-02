using System.Collections.Generic;
using HoA.Service.Contracts;
using HoA.Dal.Contracts;
using HoA.Dal.Dal;
using HoA.Entity;
using Ninject;

namespace HoA.Service.Service
{
    public class CustomerService : ICustomerService
    {
        //[Inject]
        public ICustomerDal CustomerDal { get; set; }

        public CustomerService(ICustomerDal customerDal)
        {
            CustomerDal = customerDal;
        }
        public bool Insert(Customer customer)
        {
            return CustomerDal.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return CustomerDal.Update(customer);
        }

        public IList<Customer> GetAll()
        {
            return CustomerDal.GetAll();
        }

        public Customer Get(Customer customer)
        {
            return CustomerDal.Get(customer);
        }

        public bool Delete(Customer customer)
        {
            return CustomerDal.Delete(customer);
        }
    }
}
