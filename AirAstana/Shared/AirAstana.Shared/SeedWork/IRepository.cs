using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Shared.SeedWork
{
    /// <summary>
    ///     The repository interface.
    /// </summary>
    /// <typeparam name="TEntity">The entity class.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        /// <summary>
        ///     Gets the specified filter.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);
        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Inserts the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void InsertRange(TEntity[] entities);
        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);
        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);
        /// <summary>
        ///     Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        void Delete(TEntity entityToDelete);
        /// <summary>
        ///     Deletes the range.
        /// </summary>
        /// <param name="entitiesToDelete">The entities to delete.</param>
        void DeleteRange(TEntity[] entitiesToDelete);
        /// <summary>
        ///     Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        void Update(TEntity entityToUpdate);
    }
}
