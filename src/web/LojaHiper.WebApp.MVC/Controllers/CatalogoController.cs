using LojaHiper.WebApp.MVC.Models;
using LojaHiper.WebApp.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LojaHiper.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {

        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [Route("")]
        [Route("catalogo/todos")]
        public async Task<IActionResult> index()
        {
            return View(await _catalogoService.ObterTodos());
        }

        [HttpGet]
        [Route("catalogo/produto-detalhe/{id:guid}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _catalogoService.ObterPorId(id));
        }

        [HttpGet]
        [Route("catalogo/cadastrar-produto/")]
        public async Task<IActionResult> CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        [Route("catalogo/cadastrar-produto/")]
        public async Task<IActionResult> CadastrarProduto(ProdutoViewModel produtoViewModel)
        {

            if (!ModelState.IsValid) return View(produtoViewModel);

            var produtoResponse = await _catalogoService.Cadastrar(produtoViewModel);

            if (ResponsePossuiErros(produtoResponse.ResponseResult)) return View(produtoViewModel);

            return RedirectToAction("Index", "Catalogo");
        }

        [HttpGet]
        [Route("catalogo/produto-editar/{id:guid}")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await _catalogoService.ObterPorId(id));
        }

        [HttpPost]
        [Route("catalogo/produto-editar/{id:guid}")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoViewModel produtoViewModel)
        {
            var produtoResponse = await _catalogoService.Atualizar(id, produtoViewModel);

            if (ResponsePossuiErros(produtoResponse.ResponseResult)) return View(produtoViewModel);

            return RedirectToAction("Index", "Catalogo");
        }

        [HttpGet]
        [Route("catalogo/produto-excluir/{id:guid}")]
        public async Task<IActionResult> ExcluirProduto(Guid id)
        {
            await _catalogoService.Remover(id);

            return RedirectToAction("Index", "Catalogo");
        }
    }
}
