using System.Collections.Generic;
using DapperExtensions;
using HoA.Dal.Contracts;
using HoA.Dal.Helper;
using HoA.Entity;

namespace HoA.Dal.Dal
{
    public class CustomerDal : ICustomerDal
    {
        private readonly SqlHelper SqlHelper;
        public CustomerDal()
        {
            SqlHelper = new SqlHelper();
        }
        public bool Insert(Customer customer)
        {
            return SqlHelper.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return SqlHelper.Update(customer);
        }

        public IList<Customer> GetAll()
        {
            return SqlHelper.GetAll<Customer>();
        }

        public Customer Get(Customer customer)
        {
            var predicateGroup = new PredicateGroup
            {
                Operator = GroupOperator.And,
                Predicates = new List<IPredicate>()
            };
            predicateGroup.Predicates.Add(Predicates.Field<Customer>(f=>f.ID, Operator.Eq, customer.ID));
            return SqlHelper.Find<Customer>(predicateGroup);
        }

        public bool Delete(Customer customer)
        {
            var predicateGroup = new PredicateGroup
            {
                Operator = GroupOperator.And,
                Predicates = new List<IPredicate>()
            };
            predicateGroup.Predicates.Add(Predicates.Field<Customer>(f => f.ID, Operator.Eq, customer.ID));
            return SqlHelper.Delete<Customer>(predicateGroup);
        }
    }
}
