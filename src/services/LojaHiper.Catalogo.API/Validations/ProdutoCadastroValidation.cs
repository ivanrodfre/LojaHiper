using FluentValidation;
using LojaHiper.Catalogo.API.Models;

namespace LojaHiper.Catalogo.API.Validations
{
    public class ProdutoCadastroValidation : AbstractValidator<Produto>
    {
        public ProdutoCadastroValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");
        }
    }
}
