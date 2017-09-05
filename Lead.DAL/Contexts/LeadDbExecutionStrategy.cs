using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Lead.DAL.Contexts
{
    /// <summary>
    /// This class is used to configure connection resilience, if SQL server returns a transient error (deadlock, timeout)
    /// then we will retry. Connections fail more often when deployed to the cloud so this is required
    /// </summary>
    public class LeadDbExecutionStrategy : DbExecutionStrategy
    {
        /// <summary>
        /// The default retry limit is 5, which means that the total amount of time spent 
        /// between retries is 26 seconds plus the random factor.
        /// </summary>
        public LeadDbExecutionStrategy()
        {
        }

        /// <summary>
        /// Creates a new instance of "RegistrationDbExecutionStrategy" with the specified limits for
        /// number of retries and the delay between retries.
        /// </summary>
        /// <param name="maxRetryCount"> The maximum number of retry attempts. </param>
        /// <param name="maxDelay"> The maximum delay in milliseconds between retries. </param>
        public LeadDbExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    1205,  //Deadlock
                    -2,    //Timeout
                     53 //Provider failed to open
                   
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
               
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    } 

}
