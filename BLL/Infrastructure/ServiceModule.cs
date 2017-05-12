using Ninject.Modules;
using DAL.Interfaces;
using DAL;


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
        }
    }
}
