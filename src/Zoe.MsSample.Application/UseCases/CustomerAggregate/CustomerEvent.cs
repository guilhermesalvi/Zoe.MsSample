using System;
using Zoe.Domain.Messages;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate
{
    public class CustomerEvent : Event
    {
        public Guid Id { get; protected set; }
        public string FullName { get; protected set; }
        public string Alias { get; protected set; }
        public string NormalizedFullName { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }
    }
}
