using LojaHiper.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace LojaHiper.Catalogo.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {

        private readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool IsValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true
                });
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", _notifier.GetNotifications().Select(x => x.Message).ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) NotifierErroModelInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifierErroModelInvalid(ModelStateDictionary modalState)
        {
            var errors = modalState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifierError(errorMessage);
            }

        }

        protected void NotifierError(string message)
        {
            _notifier.Handle(new NotificationMessage(message));
        }

    }
}