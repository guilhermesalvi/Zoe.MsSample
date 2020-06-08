using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer
{
    public class CustomerRemovedEventHandler : INotificationHandler<CustomerRemovedEvent>
    {
        public Task Handle(CustomerRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
