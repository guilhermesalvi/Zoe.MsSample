using FluentValidation;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer
{
    public class RegisterCustomerValidation : CustomerValidation<RegisterCustomerCommand>
    {
        public RegisterCustomerValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            base.ValidateFullName();
            base.ValidateAlias();
            base.ValidateEmail();
            base.ValidateBirthDate();
        }
    }
}
