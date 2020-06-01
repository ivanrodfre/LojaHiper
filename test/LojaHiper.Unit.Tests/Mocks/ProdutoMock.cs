using Bogus;
using LojaHiper.Catalogo.API.Models;

namespace LojaHiper.Unit.Tests.Mocks
{
    public static class ProdutoMock
    {
        public static Faker<Produto> ProdutoModelFaker =>
            new Faker<Produto>()
            .CustomInstantiator(x => new Produto
            (
                nome: x.Random.String(),
                preco: x.Finance.Amount(10m, 1000m),
                estoque: x.Random.Number(1, 10)
             ));

    }
}
