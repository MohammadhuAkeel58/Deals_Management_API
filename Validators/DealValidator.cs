// using System;
// using DealsManagement.DTO;
// using FluentValidation;

// namespace DealsManagement.Validators;

// public class DealValidator : AbstractValidator<DealDto>
// {

//     public DealValidator()
//     {
//         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(20).WithMessage("Name cannot be more than 20 characters");
//         RuleFor(x => x.Slug).NotEmpty().WithMessage("Slug is required").MaximumLength(20).WithMessage("Slug cannot be more than 20 characters");
//         RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MaximumLength(50).WithMessage("Title cannot be more than 50 characters");
//         RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required").Matches(@"^.*\.(jpg|jpeg|png|gif|bmp)$").MaximumLength(100).WithMessage("Image cannot be more than 100 characters");
//         RuleForEach(x => x.Hotels).SetValidator(new HotelValidator());
//     }
// }
