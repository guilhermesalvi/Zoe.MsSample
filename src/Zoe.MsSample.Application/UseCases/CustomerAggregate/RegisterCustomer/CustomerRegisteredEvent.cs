using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer
{
    public class CustomerRegisteredEvent : CustomerEvent
    {
        public CustomerRegisteredEvent(Guid id,
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
