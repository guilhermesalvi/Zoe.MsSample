using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer
{
    public class CustomerRegisteredEventHandler : INotificationHandler<CustomerRegisteredEvent>
    {
        public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
