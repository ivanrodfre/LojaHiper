using FluentValidation;
using LojaHiper.Catalogo.API.Models;

namespace LojaHiper.Catalogo.API.Validations
{
    public class ProdutoUpdateValidation : AbstractValidator<Produto>
    {
        public ProdutoUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio")
                .NotNull().WithMessage("Id não pode ser null");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

        }
    }
}
