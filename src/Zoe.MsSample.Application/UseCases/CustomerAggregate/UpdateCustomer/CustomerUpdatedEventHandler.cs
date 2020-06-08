using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer
{
    public class CustomerUpdatedEventHandler : INotificationHandler<CustomerUpdatedEvent>
    {
        public Task Handle(CustomerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
