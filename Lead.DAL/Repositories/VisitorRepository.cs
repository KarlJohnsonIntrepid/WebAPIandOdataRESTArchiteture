using Lead.DAL.Contexts;
using Lead.Models.Entities;

namespace Lead.DAL.Repositories
{
    public class VisitorRepository : Repository<Visitor>
    {
        public VisitorRepository(LeadDbContext dbContext) : base(dbContext)
        {

        }
    }
}
