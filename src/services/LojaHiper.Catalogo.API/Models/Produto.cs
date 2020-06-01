using LojaHiper.Core.DomainObjects;

namespace LojaHiper.Catalogo.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {

        public Produto()
        {

        }

        public Produto(string nome, decimal preco, int estoque)
        {
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
