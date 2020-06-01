using LojaHiper.Core.Date;
using LojaHiper.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;

namespace LojaHiper.Catalogo.API.Date.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        protected readonly CatalogoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(CatalogoContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
