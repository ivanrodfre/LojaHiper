using LojaHiper.Catalogo.API.Date;
using LojaHiper.Core.Date;

namespace LojaHiper.Catalogo.API.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CatalogoContext _context;

        public UnitOfWork(CatalogoContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
