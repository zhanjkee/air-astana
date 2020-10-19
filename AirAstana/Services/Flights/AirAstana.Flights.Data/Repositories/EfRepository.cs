using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Data.Context;
using AirAstana.Shared.SeedWork;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.Repositories
{
    /// <summary>
    ///     The base entity framework repository class.
    /// </summary>
    /// <typeparam name="TEntity">The entity class.</typeparam>
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        [NotNull]
        private readonly FlightsContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        public EfRepository([NotNull] FlightsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        ///     Gets the db set.
        /// </summary>
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        ///     Gets the specified filter.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            // Fetch a Queryable that includes all expression-based includes.
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(DbSet.AsQueryable(),
                    (current, include) => current.Include(include));

            // Modify the IQueryable to include any string-based include statements.
            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // Return the result of the query using the specification's criteria expression.
            return await secondaryResult
                            .Where(specification.Criteria)
                            .ToListAsync(cancellationToken);
        }

        /// <summary>
        ///     Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        ///     Inserts the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertRange(TEntity[] entities)
        {
            DbSet.AddRange(entities);
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(object id)
        {
            Delete(DbSet.Find(id));
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            Delete(await DbSet.FindAsync(id, cancellationToken));
        }

        /// <summary>
        ///     Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        ///     Deletes the range.
        /// </summary>
        /// <param name="entitiesToDelete">The entities to delete.</param>
        public virtual void DeleteRange(TEntity[] entitiesToDelete)
        {
            DbSet.RemoveRange(entitiesToDelete);
        }

        /// <summary>
        ///     Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Update(entityToUpdate);
        }
    }
}

