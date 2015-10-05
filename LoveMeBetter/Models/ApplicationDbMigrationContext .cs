namespace LoveMeBetter.Models
{
    public class ApplicationDbMigrationContext : ApplicationDbContext
    {
        public ApplicationDbMigrationContext(ApplicationDbInitializer applicationDbInitializer) : base(applicationDbInitializer)
        {
        }
    }
}