using FluentValidation;
using Tesodev.Case.Order.Application.Commands;

namespace Tesodev.Case.Customer.Application.Validations;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(command => command.AddressLine).NotEmpty().WithMessage("AddressLine is required");
        RuleFor(command => command.City).NotEmpty().WithMessage("City is required");
        RuleFor(command => command.CityCode).NotEmpty().GreaterThan(0).WithMessage("CityCode is required");
        RuleFor(command => command.Country).NotEmpty().WithMessage("Country is required");
        RuleFor(command => command.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(command => command.ProductImageUrl).NotEmpty().WithMessage("ProductImageUrl is required");
        RuleFor(command => command.ProductName).NotEmpty().WithMessage("ProductName is required");
        RuleFor(command => command.ProductQuantity).NotEmpty().GreaterThan(0).WithMessage("ProductQuantity is required");
        RuleFor(command => command.ProductUnitPrice).NotEmpty().GreaterThan(0).WithMessage("ProductUnitPrice is required");
    }
}