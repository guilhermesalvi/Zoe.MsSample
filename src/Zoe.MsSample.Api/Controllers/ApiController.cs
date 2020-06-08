using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoe.ApplicationMessage.Managers;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;
using Zoe.MsSample.Api.Results;

namespace Zoe.MsSample.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;
        private readonly IApplicationMessageManager _appMessageManager;

        protected IEnumerable<DomainNotification> Notifications => this._notifications.Notifications;
        protected bool IsValidOperation => !this._notifications.HasNotifications;

        public ApiController(IMediatorHandler mediator,
                             INotificationHandler<DomainNotification> notifications,
                             IApplicationMessageManager appMessageManager)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._notifications = (DomainNotificationHandler)notifications ?? throw new ArgumentNullException(nameof(notifications));
            this._appMessageManager = appMessageManager ?? throw new ArgumentNullException(nameof(appMessageManager));
        }

        protected new IActionResult Response<T>(T data = null) where T : class
        {
            if (this.IsValidOperation)
            {
                return Ok(new ResultBase<T>(data));
            }

            return StatusCode(422, new ResultBase<T>(this.RenderApplicationMessages()));
        }

        protected async Task NotifyModelStateErrors()
        {
            foreach (var error in this.ModelState.Values.SelectMany(x => x.Errors))
            {
                var errorMessage = error.Exception is null ? error.ErrorMessage : error.Exception.Message;
                await this.NotifyErrorAsync(nameof(ModelState), errorMessage);
            }
        }

        protected async Task NotifyErrorAsync(string key, string value)
        {
            await this._mediator.RaiseEventAsync(new DomainNotification(key, value));
        }

        private IEnumerable<ApplicationError> RenderApplicationMessages()
        {
            var list = new List<ApplicationError>();

            foreach (var notification in this.Notifications)
            {
                var message = this._appMessageManager.FindBySelector(notification.Value);
                list.Add(new ApplicationError
                {
                    Key = message?.ExternalCode ?? "ApplicationError",
                    Value = message?.FriendlyText ?? "Tivemos um problema durante a execução da requisição."
                });
            }

            return list;
        }
    }
}
