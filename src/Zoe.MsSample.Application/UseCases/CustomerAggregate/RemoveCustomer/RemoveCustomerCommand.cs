using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public override bool IsValid
        {
            get
            {
                base.ValidationResult = new RemoveCustomerValidation().Validate(this);
                return base.ValidationResult.IsValid;
            }
        }

        public RemoveCustomerCommand(Guid id)
        {
            base.Id = id;
        }
    }
}
