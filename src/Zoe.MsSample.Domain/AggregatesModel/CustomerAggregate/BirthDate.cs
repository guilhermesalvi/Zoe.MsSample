using System;
using System.Collections.Generic;
using Zoe.Domain.Models;

namespace Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate
{
    public class BirthDate : ValueObject<BirthDate>
    {
        private DateTime _value;

        public DateTime Value
        {
            get => this._value;
            private set
            {
                if (value == default) throw new ArgumentNullException(nameof(value));

                this._value = value;
            }
        }

        protected BirthDate() { }

        public BirthDate(DateTime value)
        {
            this.Value = value;
        }

        public BirthDate SetNewValue(DateTime newValue)
        {
            return new BirthDate(newValue);
        }

        protected override IEnumerable<object> GetAtomically()
        {
            yield return this.Value;
        }
    }
}
