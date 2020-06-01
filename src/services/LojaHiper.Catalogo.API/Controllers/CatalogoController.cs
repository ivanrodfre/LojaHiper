using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Models;
using LojaHiper.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaHiper.Catalogo.API.Controllers
{
    public class CatalogoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoService produtoService,
                                  IProdutoRepository produtoRepository,
                                  INotifier notifier) : base(notifier)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
        }

        [HttpGet("catalogo/produtos")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            return Ok(await _produtoRepository.GetAllAsync());
        }

        [HttpGet("catalogo/produtos/{id:guid}")]
        public async Task<ActionResult<Produto>> GetDetails(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [Route("catalogo/produtos")]
        [HttpPost]
        public async Task<ActionResult<Produto>> Adicionar([FromBody]Produto produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.AddAsync(produto);

            return CustomResponse(produto);
        }

        [Route("catalogo/produtos/{id:guid}")]
        [HttpPut]
        public async Task<ActionResult<Produto>> Atualziar(Guid id, [FromBody]Produto produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.UpdateAsync(id, produto);

            return CustomResponse(produto);
        }

        [Route("catalogo/produtos/{id:guid}")]
        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _produtoService.RemoveAsync(id);
            
            return CustomResponse();
        }
    }
}
