using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HighestPayingCompanies.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EFDbContext() : base("DefautConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}