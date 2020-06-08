using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer
{
    public class CustomerRemovedEvent : CustomerEvent
    {
        public CustomerRemovedEvent(Guid id,
                                    string fullName,
                                    string alias,
                                    string normalizedFullName,
                                    string email,
                                    DateTime birthDate)
        {
            base.AggregateId = id;
            base.Id = id;
            base.FullName = fullName;
            base.Alias = alias;
            base.NormalizedFullName = normalizedFullName;
            base.Email = email;
            base.BirthDate = birthDate;
        }
    }
}
