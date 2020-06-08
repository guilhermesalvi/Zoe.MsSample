using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;

namespace Zoe.MsSample.Application.PipelineBehavior
{
    public class FailFastValidationRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IMediatorHandler _mediator;

        public FailFastValidationRequestBehavior(IEnumerable<IValidator<TRequest>> validators,
                                                 IMediatorHandler mediator)
        {
            this._validators = validators ?? throw new ArgumentNullException(nameof(validators));
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = this._validators
                             .Select(x => x.ValidateAsync(request).Result)
                             .SelectMany(x => x.Errors)
                             .Where(x => x != null)
                             .Select(x => x.ErrorMessage);

            return errors == null || errors.Count() == 0
                ? await next()
                : await this.NotifyErrors(errors);
        }

        private async Task<TResponse> NotifyErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                await this._mediator.RaiseEventAsync(new DomainNotification("ValidationFailure", error));
            }

            return default;
        }
    }
}
