using System;
using System.Data;
using DealsManagement.DTO;
using FluentValidation;

namespace DealsManagement.Validators;

public class HotelValidator : AbstractValidator<HotelDto>
{

    public HotelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(20).WithMessage("Name cannot be more than 20 characters");
        RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required").MaximumLength(50).WithMessage("Location cannot be more than 50 characters");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").MaximumLength(1000).WithMessage("Description cannot be more than 1000 characters");
    }

}
