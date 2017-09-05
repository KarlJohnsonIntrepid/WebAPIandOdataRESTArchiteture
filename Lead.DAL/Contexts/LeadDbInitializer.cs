using System;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace Lead.DAL.Contexts
{
    public class LeadDbInitializer : CreateDatabaseIfNotExists<LeadDbContext>
    {

        protected override void Seed(LeadDbContext context)
        {

           // var seeder = new SeedExecuter(context);
           // seeder.Seed(context);

            base.Seed(context);
        }
    }
}
