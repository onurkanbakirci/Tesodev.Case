using FluentValidation;
using Tesodev.Case.Customer.Application.Commands;

namespace Tesodev.Case.Customer.Application.Validations;

public class UpdateCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(command => command.AddressLine).NotEmpty().WithMessage("AddressLine is required");
        RuleFor(command => command.City).NotEmpty().WithMessage("City is required");
        RuleFor(command => command.CityCode).NotEmpty().GreaterThan(0).WithMessage("CityCode is required");
        RuleFor(command => command.Country).NotEmpty().WithMessage("Country is required");
        RuleFor(command => command.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required");
    }
}