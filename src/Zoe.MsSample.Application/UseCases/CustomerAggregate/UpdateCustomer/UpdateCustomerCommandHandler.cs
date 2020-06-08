using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zoe.Data.UoW;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;
using Zoe.Domain.Results;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _mediator;
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(IUnitOfWork uow,
                                            IMediatorHandler mediator,
                                            ICustomerRepository repository)
        {
            this._uow = uow ?? throw new ArgumentNullException(nameof(uow));
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<CommandResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await this._repository.GetByIdAsync(message.Id);

                if (customer is null)
                {
                    await this.NotifyForNonExistentCustomer();
                    return CommandResult.Fail;
                }

                customer.SetNewName(new Name(message.FullName, message.Alias));
                customer.SetNewEmail(new Email(message.Email));
                customer.SetNewBirthDate(new BirthDate(message.BirthDate));

                this._repository.Update(customer);

                if (await this._uow.CommitAsync())
                {
                    await this._mediator.RaiseEventAsync(new CustomerUpdatedEvent(customer.Id,
                                                                                  customer.Name.FullName,
                                                                                  customer.Name.Alias,
                                                                                  customer.Name.NormalizedFullName,
                                                                                  customer.Email.Address,
                                                                                  customer.BirthDate.Value));

                    return new CommandResult(true, "Cliente atualizado com sucesso!");
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

        private async Task NotifyForNonExistentCustomer()
        {
            await this._mediator.RaiseEventAsync(new DomainNotification(nameof(RegisterCustomerCommand), CustomerErrorAcronyms.CUSTOMER_NON_EXISTENT));
        }

        private async Task NotifyForFailureDuringDataProcessing()
        {
            await this._mediator.RaiseEventAsync(new DomainNotification(nameof(UpdateCustomerCommand), CustomerErrorAcronyms.CUSTOMER_FAILURE_DURING_DATA_PROCESSING));
        }
    }
}
