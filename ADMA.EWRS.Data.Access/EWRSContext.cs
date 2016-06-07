using ADMA.EWRS.Data.Access.EFConfigurations;
using ADMA.EWRS.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ADMA.EWRS.Data.Access
{
    public class EWRSContext : DbContext
    {
        const string _connectionString = @"Data Source=MURAD-LP\SQL2K16;Initial Catalog=EWRSD;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public EWRSContext()
            : base(_connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<EWRSContext>(null); //Murad disable migration to now 
        }

        public virtual DbSet<Murad> Muradies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MuradConfiguration());
        }

        


    }
}
