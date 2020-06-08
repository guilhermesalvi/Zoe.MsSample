using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zoe.Data.UoW;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;
using Zoe.Domain.Results;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, CommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _mediator;
        private readonly ICustomerRepository _repository;

        public RegisterCustomerCommandHandler(IUnitOfWork uow,
                                              IMediatorHandler mediator,
                                              ICustomerRepository repository)
        {
            this._uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<CommandResult> Handle(RegisterCustomerCommand message, CancellationToken cancellationToken)
        {
            try
            {
                var alreadyExists = await this._repository.GetByEmailAddressAsync(message.Email);

                if (alreadyExists != null)
                {
                    await this.NotifyForAlreadyExistEmailAddress();
                    return CommandResult.Fail;
                }

                var customer = new Customer(Guid.NewGuid(),
                                            new Name(message.FullName, message.Alias),
                                            new Email(message.Email),
                                            new BirthDate(message.BirthDate));

                this._repository.Add(customer);

                if (await this._uow.CommitAsync())
                {
                    await this._mediator.RaiseEventAsync(new CustomerRegisteredEvent(customer.Id,
                                                                                     customer.Name.FullName,
                                                                                     customer.Name.Alias,
                                                                                     customer.Name.NormalizedFullName,
                                                                                     customer.Email.Address,
                                                                                     customer.BirthDate.Value));

                    return new CommandResult(true, "Cliente cadastrado com sucesso!");
                }

                await this.NotifyForFailureDuringDataProcessing();
                return CommandResult.Fail;
            }
            catch (Exception)
            {
                await this.NotifyForFailureDuringDataProcessing();
                return CommandResult.Fail;
            }
        }

        private async Task NotifyForAlreadyExistEmailAddress()
        {
            await this._mediator.RaiseEventAsync(new DomainNotification(nameof(RegisterCustomerCommand), CustomerErrorAcronyms.CUSTOMER_EMAIL_ALREADY_EXISTS));
        }

        private async Task NotifyForFailureDuringDataProcessing()
        {
            await this._mediator.RaiseEventAsync(new DomainNotification(nameof(RegisterCustomerCommand), CustomerErrorAcronyms.CUSTOMER_FAILURE_DURING_DATA_PROCESSING));
        }
    }
}
