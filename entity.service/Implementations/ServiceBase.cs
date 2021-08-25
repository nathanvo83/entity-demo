using AutoMapper;
using entity.data;
using entity.data.Entity;
using entity.service.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace entity.service.Implementations
{
    internal abstract class ServiceBase<TModel, TEntity>
        where TModel : ModelBase
        where TEntity : EntityBase
    {
        protected IMapper Mapper { get; private set; }
        protected tododbContext Db { get; private set; }
        protected DbSet<TEntity> Set { get; private set; }
        protected abstract string[] DefaultIncludes { get; }

        protected ServiceBase(IMapper mapper, tododbContext db)
        {
            Mapper = mapper;
            Db = db;
            Set = Db.Set<TEntity>();
        }

        public virtual void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
                Db = null;
            }
        }

        public virtual async Task<IList<TModel>> Query(Expression<Func<TModel, bool>> predicate = null)
        {
            IQueryable<TEntity> query = Set.AsNoTracking();
            IQueryable<TEntity> result;

            foreach (var include in DefaultIncludes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                var p = Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
                result = query.Where(p);
            }
            else
            {
                result = query;
            }


            return Mapper.Map<IList<TModel>>(await result.ToListAsync());
        }

        public virtual async Task<TModel> Single(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TEntity> query = Set.AsNoTracking();

            foreach (var include in DefaultIncludes)
            {
                query = query.Include(include);
            }

            var p = Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var result = query.Where(p);

            return Mapper.Map<TModel>(await result.FirstOrDefaultAsync());
        }

        public virtual async Task<bool> Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            await Set.AddAsync(entity);
            return await Db.SaveChangesAsync() > 0;
        }

        public virtual async Task<IList<bool>> Add(IList<TModel> models)
        {
            var result = new List<bool>();
            foreach (var model in models)
            {
                result.Add(await Add(model));
            }

            return result;
        }

        public virtual async Task<bool> Update(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            Db.Entry(entity).State = EntityState.Modified;
            return await Db.SaveChangesAsync() > 0;
        }

        public virtual async Task<IList<bool>> Update(IList<TModel> models)
        {
            var result = new List<bool>();
            foreach (var model in models)
            {
                result.Add(await Update(model));
            }

            return result;
        }

        public virtual async Task<bool> Delete(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            Db.Entry(entity).State = EntityState.Deleted;
            return await Db.SaveChangesAsync() > 0;
        }

        public virtual async Task<IList<bool>> Delete(IList<TModel> models)
        {
            var result = new List<bool>();
            foreach (var model in models)
            {
                result.Add(await Delete(model));
            }

            return result;
        }
    }
}
