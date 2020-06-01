using System;

namespace LojaHiper.Core.Date
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
