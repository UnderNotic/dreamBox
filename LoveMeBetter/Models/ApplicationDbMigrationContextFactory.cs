using System.Data.Entity.Infrastructure;
using Autofac;

namespace LoveMeBetter.Models
{
    public class ApplicationDbMigrationContextFactory : IDbContextFactory<ApplicationDbMigrationContext>
    {
        private readonly IContainer _container = AutofacBootstrapper.GetContainer();
      
        public ApplicationDbMigrationContextFactory()
        {
        }

        public ApplicationDbMigrationContext Create()
        {
            return _container.Resolve<ApplicationDbMigrationContext>();
        }
    }
}