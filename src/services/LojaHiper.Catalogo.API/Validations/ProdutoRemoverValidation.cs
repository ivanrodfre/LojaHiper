using FluentValidation;
using LojaHiper.Catalogo.API.Models;

namespace LojaHiper.Catalogo.API.Validations
{
    public class ProdutoRemoverValidation : AbstractValidator<Produto>
    {
        public ProdutoRemoverValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id não pode ser vazio")
                .NotNull().WithMessage("Id não pode ser null");
        }
    }
}
