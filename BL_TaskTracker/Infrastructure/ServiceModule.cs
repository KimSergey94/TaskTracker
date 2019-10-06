using DAL_TaskTracker.Repositories;
using DAL_TaskTracker.Repositories.Interfaces;
using Ninject.Modules;


namespace BL_TaskTracker.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}