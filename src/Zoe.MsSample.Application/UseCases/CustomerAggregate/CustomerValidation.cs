using FluentValidation;
using System;

namespace Zoe.MsSample.Application.UseCases.CustomerAggregate
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_ID_FORMAT);
        }

        protected void ValidateFullName()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_EMPTY_FULLNAME)
                .Length(3, 256).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_FULLNAME_LENGHT);
        }

        protected void ValidateAlias()
        {
            RuleFor(x => x.Alias)
                .NotEmpty().WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_EMPTY_ALIAS)
                .Length(2, 20).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_ALIAS_LENGHT);
        }

        protected void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_EMPTY_EMAIL)
                .EmailAddress().WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_EMAIL_FORMAT)
                .Length(5, 256).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_EMAIL_LENGHT);
        }

        protected void ValidateBirthDate()
        {
            RuleFor(x => x.BirthDate)
                .NotEqual(default(DateTime)).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_BIRTHDATE_FORMAT)
                .Must(BeAValidBirthDate).WithMessage(CustomerErrorAcronyms.CUSTOMER_INVALID_OLDER_BIRTHDATE);
        }

        private bool BeAValidBirthDate(DateTime value)
        {
            return value <= DateTime.Now.Date.AddYears(-18);
        }
    }
}
