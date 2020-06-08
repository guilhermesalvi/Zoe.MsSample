using System;
using System.Collections.Generic;
using Zoe.Domain.Models;
using Zoe.Utility.StringExtensions;

namespace Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate
{
    public class Name : ValueObject<Name>
    {
        private string _fullName;
        private string _alias;
        private string _normalizedFullName;

        public string FullName
        {
            get => this._fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

                this._fullName = value.RemoveDuplicateSpaces().Trim();
            }
        }

        public string Alias
        {
            get => this._alias;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

                this._alias = value.RemoveDuplicateSpaces().Trim();
            }
        }

        public string NormalizedFullName
        {
            get => this._normalizedFullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

                this._normalizedFullName = value.RemoveDuplicateSpaces().NormalizeAccentedChars().ToUpper().Trim();
            }
        }

        protected Name() { }

        public Name(string fullName, string alias)
        {
            this.FullName = fullName;
            this.Alias = alias;
            this.NormalizedFullName = fullName;
        }

        public Name SetNewFullName(string newFullName)
        {
            return new Name(newFullName, this.Alias);
        }

        public Name SetNewAlias(string newAlias)
        {
            return new Name(this.FullName, newAlias);
        }

        protected override IEnumerable<object> GetAtomically()
        {
            yield return this.FullName;
            yield return this.Alias;
            yield return this.NormalizedFullName;
        }
    }
}
