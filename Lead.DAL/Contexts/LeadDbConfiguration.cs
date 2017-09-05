using System;
using System.Data.Entity;

namespace Lead.DAL.Contexts
{
    /// <summary>
    /// This class is automatically applyed to all contexts in this assembly
    /// Used to set connection resilience
    /// </summary>
    public class LeadDbConfiguration :DbConfiguration
    {
        public LeadDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new LeadDbExecutionStrategy(3, TimeSpan.FromSeconds(5)));
        }
    }
}
