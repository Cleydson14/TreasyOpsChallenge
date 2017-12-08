using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;

namespace TreasyOps.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealUpdate> DealUpdates { get; set; }
        public DbSet<Stage> Stages { get; set; }

        public Context()
          : base()
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public Context(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deal>().MapToStoredProcedures();
        }
    }    
}