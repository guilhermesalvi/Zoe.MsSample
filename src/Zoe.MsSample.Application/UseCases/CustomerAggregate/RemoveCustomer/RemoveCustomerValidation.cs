using FluentValidation;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer
{
    public class RemoveCustomerValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            base.ValidateId();
        }
    }
}
