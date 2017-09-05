using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.DAL.Contexts;

namespace Lead.DAL.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<LeadDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LeadDbContext context)
        {

          //  var seeder = new SeedExecuter(context);
          //  seeder.Seed(context);

            base.Seed(context);
        }
    }
}
