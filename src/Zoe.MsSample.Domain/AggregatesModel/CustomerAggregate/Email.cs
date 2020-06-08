using System;
using System.Collections.Generic;
using Zoe.Domain.Models;

namespace Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate
{
    public class Email : ValueObject<Email>
    {
        private string _address;

        public string Address
        {
            get => this._address;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

                this._address = value.Trim();
            }
        }

        public string NormalizedAddress => this.Address.ToUpper();

        protected Email() { }

        public Email(string address)
        {
            this.Address = address;
        }

        public Email SetNewAddress(string newAddress)
        {
            return new Email(newAddress);
        }

        protected override IEnumerable<object> GetAtomically()
        {
            yield return this.Address;
        }
    }
}
