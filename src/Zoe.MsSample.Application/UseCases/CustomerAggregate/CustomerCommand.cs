using System;
using Zoe.Domain.Messages;
using Zoe.Utility.StringExtensions;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate
{
    public abstract class CustomerCommand : Command
    {
        private string _fullName;
        private string _alias;
        private string _email;

        public Guid Id { get; protected set; }
        public DateTime BirthDate { get; protected set; }

        public string FullName
        {
            get => this._fullName;
            protected set
            {
                this._fullName = value?.NormalizeAccentedChars().RemoveDuplicateSpaces().Trim();
            }
        }

        public string Alias
        {
            get => this._alias;
            protected set
            {
                this._alias = value?.NormalizeAccentedChars().RemoveDuplicateSpaces().Trim();
            }
        }

        public string Email
        {
            get => this._email;
            protected set
            {
                this._email = value?.Trim();
            }
        }
    }
}
