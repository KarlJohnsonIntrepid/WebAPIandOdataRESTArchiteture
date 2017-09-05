using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Lead.Domain.Abstract
{
    /// <summary>
    /// Interface used to to represent a generic repository of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets a list of type T
        /// </summary>
        /// <returns>IEnumerable of T</returns>
        IEnumerable<T> List();

        /// <summary>
        /// Gets a List of Type T Async
        /// </summary>
        /// <returns>Task IEnumerable of T</returns>
        Task<IEnumerable<T>> ListAsync();

        /// <summary>
        /// Returns IQuerable of T
        /// </summary>
        /// <returns></returns>
        IQueryable<T> ListQuerable();

        /// <summary>
        /// Get value specified by the ID
        /// </summary>
        /// <param name="id" />
        /// <returns>Single value of T</returns>
        T Get(object id);

        /// <summary>
        /// Get value specified by the ID Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task with Single value of T</returns>
        Task<T> GetAsync(object id);

        /// <summary>
        /// Adds a new object to the repository
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The added object</returns>
        T Add(T t);


        /// <summary>
        /// Adds a new object to the repository Async
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The added object</returns>
        Task<T> AddAsync(T t);

        /// <summary>
        /// Updates object in the repository
        /// </summary>
        /// <param name="t">Object</param>
        /// <param name="key">Unique Identifier</param>
        /// <returns>Updated object</returns>
        T Update(T t, object key);

        /// <summary>
        /// Updates object in the repository Async
        /// </summary>
        /// <param name="t">Object</param>
        /// <param name="key">Unique Identifier</param>
        /// <returns>Updated object</returns>
        Task<T> UpdateAsync(T t, object key);

        /// <summary>
        /// Deletes object specified by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted object</returns>
        T Delete(object id);

        /// <summary>
        /// Deletes object specified by ID Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task of Deleted object</returns>
        Task<T> DeleteAsync(object id);

        /// <summary>
        /// Returns a count of all items of T
        /// </summary>
        /// <returns>Integer</returns>
        int Count();

        /// <summary>
        /// Returns a count of all items of T Asynchronously
        /// </summary>
        /// <returns>Task of type integer></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Creates a new object with default
        /// </summary>
        /// <returns>return T</returns>
        T Create();

    }
}
