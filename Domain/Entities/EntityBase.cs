using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public abstract class EntityBase<T> : AbstractValidator<T> where T : EntityBase<T>
    {
        public virtual int Id { get; set; }
        public bool IsActive { get; set; } = true;

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();
        public virtual Task<bool> IsValidAsync() => Task.FromResult(true);
    }
}