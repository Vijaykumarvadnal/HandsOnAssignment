using HoA.Service.Contracts;
using HoA.Service.Service;
using Ninject.Modules;

namespace HoA.Service
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerService>();
        }
    }
}
