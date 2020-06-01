using AutoMapper;
using LojaHiper.Catalogo.API.Interfaces;
using LojaHiper.Catalogo.API.Models;
using LojaHiper.Catalogo.API.Validations;
using LojaHiper.Core.Date;
using LojaHiper.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace LojaHiper.Catalogo.API.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IUnitOfWork unitOfWork,
                              IMapper mapper,
                              INotifier notifier) : base(notifier)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(Produto produto)
        {
            if (!ExecValidation(new ProdutoCadastroValidation(), produto)) return;

            await Task.Run(() => _produtoRepository.Add(produto));
            _unitOfWork.Commit();
        }
        public async Task UpdateAsync(Guid id, Produto produto)
        {

            if (id != produto.Id)
            {
                NotifierError("Os ids são diferentes.");
                return;
            }

            var produtoResult = await _produtoRepository.GetByIdAsync(id);

            if (produtoResult == null)
            {
                NotifierError("Este produto não existe!");
                return;
            }

            var modelProduto = _mapper.Map<Produto>(produto);
            modelProduto.Id = produtoResult.Id;


            if (!ExecValidation(new ProdutoUpdateValidation(), modelProduto)) return;

            _produtoRepository.Update(modelProduto);
            _unitOfWork.Commit();
        }

        public async Task RemoveAsync(Guid id)
        {
            var produtoResult = await _produtoRepository.GetByIdAsync(id);

            if (!ExecValidation(new ProdutoRemoverValidation(), produtoResult)) return;

            _produtoRepository.Remove(produtoResult);
            _unitOfWork.Commit();
        }

    }
}
