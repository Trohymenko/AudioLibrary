using Ninject.Modules;
using DAL.Interfaces;
using DAL;
using DAL.Identity.Interfaces;
using DAL.Identity;


namespace BLL.Infrastructure
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
            Bind<ITracksUnitOfWork>().To<TracksUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IRatesUnitOfWork>().To<RatesUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IUnitOfWorkIdentity>().To<UnitOfWorkIdentity>().WithConstructorArgument(connectionString);
        }
    }
}
