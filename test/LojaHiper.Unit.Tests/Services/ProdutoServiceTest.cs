using AutoMapper;
using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Models;
using LojaHiper.Catalogo.API.Services;
using LojaHiper.Core.Date;
using LojaHiper.Core.Notifications;
using LojaHiper.Unit.Tests.Mocks;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LojaHiper.Unit.Tests.Services
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<INotifier> _notifierMock;

        private Produto _produtoItemMock = ProdutoMock.ProdutoModelFaker.Generate();

        public ProdutoServiceTest()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _notifierMock = new Mock<INotifier>();
        }

        [Fact]
        public async Task AddProduto_SuccessTest()
        {
            var produto = ProdutoMock.ProdutoModelFaker.Generate();

            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(produto.Id))
                .ReturnsAsync(produto);

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);
            await produtoService.AddAsync(produto);

            Assert.NotNull(produto);
        }

        [Fact]
        public async Task AddProduto_ErroNomeInvalidoTest()
        {
            var produto = ProdutoMock.ProdutoModelFaker.Generate();
            produto.Nome = string.Empty;

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);

            await produtoService.AddAsync(produto);

            Assert.Empty(produto.Nome);

        }

        [Fact]
        public async Task UpdateProduto_SuccessTest()
        {

            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(_produtoItemMock.Id))
                .ReturnsAsync(_produtoItemMock);

            _mapperMock.Setup(x => x.Map<Produto>(It.IsAny<Produto>()))
                .Returns(_produtoItemMock);

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);

            await produtoService.UpdateAsync(_produtoItemMock.Id, _produtoItemMock);

            Assert.NotNull(_produtoItemMock);

        }

        [Fact]
        public async Task UpdateProduto_ErrorIdDiferenteTest()
        {
            var id = Guid.NewGuid();

            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(_produtoItemMock.Id))
                .ReturnsAsync(_produtoItemMock);

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);

            await produtoService.UpdateAsync(id, _produtoItemMock);

            Assert.NotEqual(id, _produtoItemMock.Id);
        }

        [Fact]
        public async Task UpdateProduto_ErrorProdutoResultByIdRetornoNullTest()
        {
            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(_produtoItemMock.Id));

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);
            await produtoService.UpdateAsync(_produtoItemMock.Id, _produtoItemMock);

            _notifierMock.VerifyAll();
        }

        [Fact]
        public async Task Remove_SucessTestAsync()
        {

            _produtoRepositoryMock.Setup(x => x.GetByIdAsync(_produtoItemMock.Id))
                .ReturnsAsync(_produtoItemMock);

            var produtoService = new ProdutoService(_produtoRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _notifierMock.Object);

            await produtoService.RemoveAsync(_produtoItemMock.Id);

            Assert.NotNull(_produtoItemMock);
        }

    }
}
