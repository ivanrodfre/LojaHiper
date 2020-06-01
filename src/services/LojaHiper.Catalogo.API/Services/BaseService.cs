using FluentValidation;
using FluentValidation.Results;
using LojaHiper.Core.DomainObjects;
using LojaHiper.Core.Notifications;

namespace LojaHiper.Catalogo.API.Services
{
    public abstract class BaseService
    {

        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notifier(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifierError(error.ErrorMessage);
            }
        }

        protected void NotifierError(string mensagem)
        {
            _notifier.Handle(new NotificationMessage(mensagem));
        }

        protected bool ExecValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notifier(validator);

            return false;
        }

    }
}
