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
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        [NotNull]
        private readonly FlightsContext _context;

        protected EfRepository([NotNull] FlightsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var queryable = DbSet.AsQueryable();

            // Fetch a Queryable that includes all expression-based includes or explicit loading.
            if (specification.ExplicitLoading) await queryable.LoadAsync(cancellationToken);
            else
            {
                queryable = specification.Includes
                    .Aggregate(queryable,
                        (current, include) => current.Include(include));
            }

            // Modify the IQueryable to include any string-based include statements.
            queryable = specification.IncludeStrings
                .Aggregate(queryable,
                    (current, include) => current.Include(include));

            // Return the result of the query using the specification's criteria expression.
            return specification.Criteria == null
                ? await queryable.ToListAsync(cancellationToken)
                : await queryable.Where(specification.Criteria).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public virtual void InsertRange(TEntity[] entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            Delete(DbSet.Find(id));
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(TEntity[] entitiesToDelete)
        {
            DbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var originalEntity = _context.Flights.Find(entityToUpdate.Id);
            _context.Entry(originalEntity).CurrentValues.SetValues(entityToUpdate);
        }
    }
}

