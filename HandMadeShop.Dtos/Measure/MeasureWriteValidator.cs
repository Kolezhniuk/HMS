using FluentValidation;

namespace HandMadeShop.Dtos.Measure
{
    public class MeasureWriteValidator : AbstractValidator<WriteMeasureDto>
    {
        public MeasureWriteValidator()
        {
            RuleFor(x => x.Name).EmailAddress();
        }
    }
}