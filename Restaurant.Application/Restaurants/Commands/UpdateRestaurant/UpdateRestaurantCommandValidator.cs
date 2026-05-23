using FluentValidation;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator:AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(r => r.Name)
            .Length(3, 100);

        RuleFor(r => r.Description)
            .NotEmpty();

    }
}
