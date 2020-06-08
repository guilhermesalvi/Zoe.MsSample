using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer
{
    public class RegisterCustomerCommand : CustomerCommand
    {
        public override bool IsValid
        {
            get
            {
                base.ValidationResult = new RegisterCustomerValidation().Validate(this);
                return base.ValidationResult.IsValid;
            }
        }

        public RegisterCustomerCommand(string fullName,
                                       string alias,
                                       string email,
                                       DateTime birthDate)
        {
            base.FullName = fullName;
            base.Alias = alias;
            base.Email = email;
            base.BirthDate = birthDate;
        }
    }
}
