using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public override bool IsValid
        {
            get
            {
                base.ValidationResult = new UpdateCustomerValidation().Validate(this);
                return base.ValidationResult.IsValid;
            }
        }

        public UpdateCustomerCommand(Guid id,
                                     string fullName,
                                     string alias,
                                     string email,
                                     DateTime birthDate)
        {
            base.Id = id;
            base.FullName = fullName;
            base.Alias = alias;
            base.Email = email;
            base.BirthDate = birthDate;
        }
    }
}
