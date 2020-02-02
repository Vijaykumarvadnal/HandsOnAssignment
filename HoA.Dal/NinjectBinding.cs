using HoA.Dal.Contracts;
using HoA.Dal.Dal;
using Ninject.Modules;

namespace HoA.Dal
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerDal>().To<CustomerDal>();
        }
    }
}
