using LojaHiper.Catalogo.API.Models;
using System;
using System.Threading.Tasks;

namespace LojaHiper.Catalogo.API.Interfaces
{
    public interface IProdutoService
    {
        Task AddAsync(Produto produto);
        Task UpdateAsync(Guid id, Produto produto);
        Task RemoveAsync(Guid id);
    }
}
