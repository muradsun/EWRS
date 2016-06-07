using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    // Migrations are considered configured for MyDbContext because this class implementation exists.
    internal sealed class DbConfiguration : DbMigrationsConfiguration<EWRSContext>
    {
        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }
    }

}
