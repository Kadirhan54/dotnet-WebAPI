using FluentValidation;

namespace WebApi.API.Models.Validators
{

    public class BankAccountValidator : AbstractValidator<GetBankAccountDataResponseModel>
    {
        public BankAccountValidator() 
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("Please ensure that you have entered your FirstName").Length(1, 20).WithMessage("Please ensure that FirstName doesn't exceed 20 char!");
            RuleFor(x => x.LastName).NotNull().WithMessage("Please ensure that you have entered your Surname").Length(1, 20).WithMessage("Please ensure that Surname doesn't exceed 20 char!"); ;
            RuleFor(x => x.Balance).NotNull().GreaterThan(0).WithMessage("Balance cannot be negative!");
        }
    }
}
