using AutoMapper;
using System;
using System.Threading.Tasks;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;
using Zoe.MsSample.Application.Services.Abstractions;
using Zoe.MsSample.Application.UseCases.CustomerAggregate;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer;
using Zoe.MsSample.Application.ViewModels;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMediatorHandler _mediator;
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerAppService(IMediatorHandler mediator,
                                  ICustomerRepository repository,
                                  IMapper mapper)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerViewModel> GetByIdAsync(Guid id)
        {
            var customer = await this._repository.GetByIdAsync(id);

            if (customer is null)
            {
                await this._mediator.RaiseEventAsync(new DomainNotification(nameof(CustomerAppService), CustomerErrorAcronyms.CUSTOMER_NON_EXISTENT));
            }

            return this._mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<string> RegisterAsync(RegisterCustomerViewModel model)
        {
            var command = this._mapper.Map<RegisterCustomerCommand>(model);
            var result = await this._mediator.SendCommandAsync(command);

            return (string)result?.Data;
        }

        public async Task<string> RemoveAsync(RemoveCustomerViewModel model)
        {
            var command = this._mapper.Map<RemoveCustomerCommand>(model);
            var result = await this._mediator.SendCommandAsync(command);

            return (string)result?.Data;
        }

        public async Task<string> UpdateAsync(UpdateCustomerViewModel model)
        {
            var command = this._mapper.Map<UpdateCustomerCommand>(model);
            var result = await this._mediator.SendCommandAsync(command);

            return (string)result?.Data;
        }
    }
}
