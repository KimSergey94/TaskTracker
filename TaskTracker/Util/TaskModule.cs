using BLL_TaskTracker.Interfaces;
using BLL_TaskTracker.Services;
using Ninject.Modules;

namespace TaskTracker.Util
{
    public class TaskModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}