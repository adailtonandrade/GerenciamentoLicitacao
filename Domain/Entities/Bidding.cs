using Domain.Enum;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Entities
{
    public class Bidding : EntityBase<Bidding>
    {
        public string Number { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OpeningDate { get; set; }

        public BiddingStatusEnum Status { get; set; }

        public override async Task<bool> IsValidAsync()
        {
            RuleFor(c => c.Description)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(c => c.Number)
                .MaximumLength(100)
                .NotEmpty();
            RuleFor(c => c.OpeningDate)
                .NotEmpty();
            RuleFor(c => c.Status)
                .NotEmpty();

            ValidationResult = await ValidateAsync(this);
            return ValidationResult.IsValid;
        }
    }
}
