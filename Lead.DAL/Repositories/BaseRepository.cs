using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.Domain.Abstract;
using Lead.DAL.Contexts;
using Lead.Models.Abstract;

namespace Lead.DAL.Repositories
{
    /// <summary>
    /// Implements the Generic Repository pattern, provides default data access classes of type T
    /// </summary>
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        public readonly LeadDbContext Context;

        public Repository(LeadDbContext dbContext)
        {
            Context = dbContext;
        }

        /// <summary>
        /// Gets a list of type T
        /// </summary>
        /// <returns>IEnumerable of T</returns>
        public virtual IEnumerable<T> List()
        {
            return Context.Set<T>().AsEnumerable();
        }

        /// <summary>
        /// Gets a List of Type T Async
        /// </summary>
        /// <returns>Task IEnumerable of T</returns>
        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Returns IQuerable of T
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> ListQuerable()
        {
            return Context.Set<T>().AsQueryable<T>();
        }

    
        /// <summary>
        /// Get value specified by the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single value of T</returns>
        public virtual T Get(object id)
        {
            return Context.Set<T>().Find(id);
        }


        /// <summary>
        /// Get value specified by the ID Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task with Single value of T</returns>
        public virtual async Task<T> GetAsync(object id)
        {
            return await Context.Set<T>().FindAsync(id);
        }


        /// <summary>
        /// Adds a new object to the repository
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The added object</returns>
        public virtual T Add(T t)
        {
            SetCreatedDate(t);
            CreateNewId(t);
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return t;
        }


        /// <summary>
        /// Adds a new object to the repository Async
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The added object</returns>
        public virtual async Task<T> AddAsync(T t)
        {
            SetCreatedDate(t);
            CreateNewId(t);
            Context.Set<T>().Add(t);
            await Context.SaveChangesAsync();
            return t;

        }

        /// <summary>
        /// Updates object in the repository
        /// </summary>
        /// <param name="t">Object</param>
        /// <param name="key">Unique Identifier</param>
        /// <returns>Updated object</returns>
        public virtual T Update(T t, object key)
        {
            if (t == null)
            {
                return null;
            }
            ;

            T e = Context.Set<T>().Find(key);
            if (e != null)
            {
                SetUpdatedDate(t);
                Context.Entry(e).CurrentValues.SetValues(t);
                Context.SaveChanges();
            }

            return t;

        }

        /// <summary>
        /// Updates object in the repository Async
        /// </summary>
        /// <param name="t">Object</param>
        /// <param name="key">Unique Identifier</param>
        /// <returns>Updated object</returns>
        public virtual async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
            {
                return null;
            }
            ;

            T e = Context.Set<T>().Find(key);
            if (e != null)
            {
                SetUpdatedDate(t);
                Context.Entry(e).CurrentValues.SetValues(t);
                await Context.SaveChangesAsync();
            }

            return t;
        }

        /// <summary>
        /// Deletes object specified by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted object</returns>
        public virtual T Delete(object id)
        {
            T e = Context.Set<T>().Find(id);
            if (e != null)
            {
                Context.Set<T>().Remove(e);
                Context.SaveChanges();
            }

            return e;
        }


        /// <summary>
        /// Deletes object specified by ID Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task of Deleted object</returns>
        public virtual async Task<T> DeleteAsync(object id)
        {
            T e = Context.Set<T>().Find(id);
            if (e != null)
            {
                Context.Set<T>().Remove(e);
                await Context.SaveChangesAsync();
            }

            return e;
        }


        /// <summary>
        /// Returns a count of all items of T
        /// </summary>
        /// <returns>Integer</returns>
        public virtual int Count()
        {
            return Context.Set<T>().Count();
        }

        /// <summary>
        /// Returns a count of all items of T Asynchronously
        /// </summary>
        /// <returns>Task of type integer></returns>
        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        /// <summary>
        /// Creates a new object with default
        /// </summary>
        /// <returns>return T</returns>
        public virtual T Create()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        private void SetCreatedDate(T t)
        {
            var e = t as Entity;
            if (e != null)
            {
                e.DateCreated = DateTime.Now;
            }
        }

        private void SetUpdatedDate(T t)
        {
            var e = t as Entity;
            if (e != null)
            {
                e.DateModified = DateTime.Now;
            }
        }

        private void CreateNewId(T t)
        {
            var e = t as Entity;
            if (e != null)
            {
                e.Id = Guid.NewGuid();
            }
        }
    }
}
