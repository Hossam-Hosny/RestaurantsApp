using FluentValidation;
using Restaurant.Application.Restaurants.Dtos;

namespace Restaurant.Application.Restaurants.Validators;

public class CreateRestaurantValidator:AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = [ "Italian","Mexican","Japanase" , "Middle East" , "Indian" , "American","Egyption" ];
    public CreateRestaurantValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3,100)
            .WithMessage("Restaurant Name should not be null or empty!");

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required!");

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose from the valid categories");
            //.Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if (!isValidCategory)
            //        context.AddFailure("Category", "Invalid category. Please choose from the valid categories");
               
            //});

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a valid email address!");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code (XX-XXX).");

        
            
            


    }
}
