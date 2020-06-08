using FluentValidation;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer
{
    public class UpdateCustomerValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            base.ValidateId();
            base.ValidateFullName();
            base.ValidateAlias();
            base.ValidateEmail();
            base.ValidateBirthDate();
        }
    }
}
