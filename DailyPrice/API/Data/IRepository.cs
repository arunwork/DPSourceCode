using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyPrice.API.Core;

namespace DailyPrice.API.Data
{
     /// <summary>
    /// Repository interface
    /// </summary>
    public interface IRepository
    {
           /// <summary>
        /// Table
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        IQueryable<T> Table<T>() where T : BaseEntity;

        /// <summary>
        /// Asynchronously find entity using identifier
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        Task<T> FindAsync<T>(string id) where T : BaseEntity, new();

        /// <summary>
        /// Asynchronously insert new entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task InsertAsync<T>(T entity) where T : BaseEntity, new();

        /// <summary>
        /// Asynchronously update entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task UpdateAsync<T>(T entity) where T : BaseEntity, new();

        /// <summary>
        /// Asynchronously update property
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="subEntities">Sub entities</param>
        /// <param name="property">Property</param>
        /// <returns></returns>
        Task UpdateProperty<T, Field>(T entity, IList<Field> subEntities, string property) where T : BaseEntity, new();

        /// <summary>
        /// Asynchronously delete entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        Task<bool> DeleteAsync<T>(string id) where T : BaseEntity;
    }
}