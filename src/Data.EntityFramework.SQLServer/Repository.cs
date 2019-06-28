using Data.Abstractions;
using Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EntityFramework.SqlServer
{
    public abstract class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        public virtual IEnumerable<TEntity> All(int page = 0, int size = 25)
        {
            return this.dbSet.OrderByDescending(e => e.Created).Skip(page * size).Take(size);
        }

        public virtual void Create(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            this.Delete(this.WithKey(id));
        }

        public virtual void Delete(TEntity entity)
        {
            this.Delete(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            this.storageContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual TEntity WithKey(int id)
        {
            return this.dbSet.FirstOrDefault(e => e.Id == id);
        }
    }
}
