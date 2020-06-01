using LojaHiper.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaHiper.WebApp.MVC.Services.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);


        Task<GenericResponse> Cadastrar(ProdutoViewModel produtoViewModel);
        Task<GenericResponse> Atualizar(Guid id, ProdutoViewModel produtoViewModel);
        Task<GenericResponse> Remover(Guid id);
    }
}
