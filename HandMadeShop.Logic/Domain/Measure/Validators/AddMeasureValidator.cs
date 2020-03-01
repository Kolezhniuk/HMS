using FluentValidation;
using HandMadeShop.Logic.Domain.Measure.Commands;

namespace HandMadeShop.Logic.Domain.Measure.Validators
{
    public class AddMeasureValidator : AbstractValidator<AddMeasureCommand>
    {
        public AddMeasureValidator()
        {
            RuleFor(x => x.Name).EmailAddress();
        }
    }
}