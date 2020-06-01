using Bogus.Extensions;
using LojaHiper.Catalogo.API.Controllers;
using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Models;
using LojaHiper.Core.Notifications;
using LojaHiper.Unit.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LojaHiper.Unit.Tests.Controllers
{
    public class CatalogoControllerTest
    {

        private readonly Mock<IProdutoService> _produtoServiceMock;
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<INotifier> _notifier;

        public CatalogoControllerTest()
        {
            _produtoServiceMock = new Mock<IProdutoService>();
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _notifier = new Mock<INotifier>();
        }

        [Fact]
        public async Task GetAll_SucessTestAsync()
        {
            _produtoRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(ProdutoMock.ProdutoModelFaker.Generate(3));

            var catalogoController = new CatalogoController(_produtoServiceMock.Object, _produtoRepositoryMock.Object, _notifier.Object);
            var catalogoRepository = await catalogoController.GetAll();

            var actionResult = Assert.IsType<OkObjectResult>(catalogoRepository.Result);
            var actionValue = Assert.IsAssignableFrom<IEnumerable<Produto>>(actionResult.Value);

            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetDetails_SucessTestAsync()
        {
            var produtoId = ProdutoMock.ProdutoModelFaker.Generate();

            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(produtoId.Id))
                .ReturnsAsync(ProdutoMock.ProdutoModelFaker.Generate());

            var catalogoController = new CatalogoController(_produtoServiceMock.Object, _produtoRepositoryMock.Object, _notifier.Object);
            var catalogoRepository = await catalogoController.GetDetails(produtoId.Id);

            var actionResult = Assert.IsType<OkObjectResult>(catalogoRepository.Result);
            var actionValue = Assert.IsType<Produto>(actionResult.Value);

            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task Adicionar_SucessTestAsync()
        {
            var produto = ProdutoMock.ProdutoModelFaker.Generate();

            _produtoServiceMock.Setup(x => x.AddAsync(produto))
                .Returns(Task.FromResult(ProdutoMock.ProdutoModelFaker.Generate()));

            var catalogoController = new CatalogoController(_produtoServiceMock.Object, _produtoRepositoryMock.Object, _notifier.Object);
            var catalogoService = await catalogoController.Adicionar(produto);

            var actionResult = Assert.IsType<OkObjectResult>(catalogoService.Result);

            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

    }
}
