using BLL_TaskTracker.Interfaces;
using BLL_TaskTracker.Services;
using Ninject.Modules;

namespace TaskTracker.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}