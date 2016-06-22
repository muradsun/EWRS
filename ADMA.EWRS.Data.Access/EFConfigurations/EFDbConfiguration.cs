using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class EFDbConfiguration : System.Data.Entity.DbConfiguration
    {
        public EFDbConfiguration()
        {
            this.SetDatabaseInitializer<EWRSContext>(null); //Murad disable migration to now 

            //Murad :: TODO : ASP.NET Core 1 RC2 -> Note: This API is now obsolete.
            //this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());


            //Murad :: TODO : Create or Use Glimpse.ADO -> Glimpse.EF6 http://getglimpse.com/Docs/Tabs
            //For logging we can use IDbCommandInterceptor  ->  http://www.entityframeworktutorial.net/entityframework6/database-command-interception.aspx
            //SetDatabaseLogFormatter(
            //(context, writeAction) => new MuradFormatter(context, writeAction));



        }
    }
}
