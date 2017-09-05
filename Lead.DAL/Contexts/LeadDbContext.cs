using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Lead.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lead.DAL.Contexts
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// This is the dbcontext used with entity framework
    /// We can declare our enity sets and validation rules in this class
    /// </summary>
    public class LeadDbContext : IdentityDbContext<ApplicationUser>
    {

        /// <summary>
        /// load default constructor and pass in the connection string
        /// </summary>
        public LeadDbContext() : base("name=Lead", throwIfV1Schema: false)
        {
            Database.SetInitializer<LeadDbContext>(new LeadDbInitializer());
        }

        public static LeadDbContext Create()
        {
            return new LeadDbContext();
        }

        /// <summary>
        /// Add in our enity sets (enities are declared in the Entities folder
        /// </summary>
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Order> Order { get; set; }

        public override int SaveChanges()
        {
            //Allow us to easier see validation errors...

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw; // You can also choose to handle the exception here...
            }
        }
    }


}

