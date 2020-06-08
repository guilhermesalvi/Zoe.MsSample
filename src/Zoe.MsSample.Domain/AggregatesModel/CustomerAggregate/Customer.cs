using System;
using Zoe.Domain.Models;

namespace Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate
{
    public class Customer : Entity<Customer>, IAggregateRoot
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public BirthDate BirthDate { get; private set; }

        /// <summary>
        /// Assuming that an entity will always be valid because
        /// its validations are performed at the application layer
        /// </summary>
        public bool IsValid => true;

        protected Customer() { }

        public Customer(Guid id,
                        Name name,
                        Email email,
                        BirthDate birthDate)
        {
            base.Id = id;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
            this.BirthDate = birthDate ?? throw new ArgumentNullException(nameof(birthDate));
        }

        public void SetNewName(Name newName)
        {
            this.Name = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public void SetNewEmail(Email newEmail)
        {
            this.Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
        }

        public void SetNewBirthDate(BirthDate newBirthDate)
        {
            this.BirthDate = newBirthDate ?? throw new ArgumentNullException(nameof(newBirthDate));
        }
    }
}
