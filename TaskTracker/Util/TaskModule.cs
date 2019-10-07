using BL_TaskTracker.Interfaces;
using BL_TaskTracker.Services;
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