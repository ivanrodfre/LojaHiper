using LojaHiper.WebApp.MVC.Extensions;
using LojaHiper.WebApp.MVC.Models;
using LojaHiper.WebApp.MVC.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LojaHiper.WebApp.MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {

        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/catalogo/produtos");

            return await DesserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response);

        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

            return await DesserializarObjetoResponse<ProdutoViewModel>(response);
        }

        public async Task<GenericResponse> Cadastrar(ProdutoViewModel produtoViewModel)
        {
            var produtoContent = ObterConteudo(produtoViewModel);

            var response = await _httpClient.PostAsync("/catalogo/produtos/", produtoContent);

            if (!TratarErrosResponse(response))
            {
                return new GenericResponse
                {
                    ResponseResult = await DesserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DesserializarObjetoResponse<GenericResponse>(response);

        }

        public async Task<GenericResponse> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            var produtoContent = ObterConteudo(produtoViewModel);

            var response = await _httpClient.PutAsync($"/catalogo/produtos/{id}", produtoContent);

            if (!TratarErrosResponse(response))
            {
                return new GenericResponse
                {
                    ResponseResult = await DesserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DesserializarObjetoResponse<GenericResponse>(response);

        }

        public async Task<GenericResponse> Remover(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/catalogo/produtos/{id}");

            return await DesserializarObjetoResponse<GenericResponse>(response);

        }

    }
}
