using LojaHiper.Catalogo.API.Models;
using LojaHiper.Core.Date;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaHiper.Catalogo.API.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(Guid id);

    }
}
