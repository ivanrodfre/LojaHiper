using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaHiper.Catalogo.API.Date.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CatalogoContext db) : base(db)
        {
        }

        //Repositório flexivel para caso queira implementar o Dapper nas consultas =)
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await Db.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            return await Db.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
