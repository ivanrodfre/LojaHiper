using LojaHiper.Core.DomainObjects;
using System;

namespace LojaHiper.Core.Date
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity, IAggregateRoot
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
