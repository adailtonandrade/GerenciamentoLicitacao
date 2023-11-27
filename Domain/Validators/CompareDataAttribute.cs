using System.ComponentModel.DataAnnotations;

namespace Domain.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CompareDataAttribute : ValidationAttribute
    {
        public string _param1 { get; private set; }
        public string _param2 { get; private set; }
        public CompareDataAttribute(string param1, string param2)
        {
            _param1 = param1;
            _param2 = param2;
        }

        public string FormatErrorMessage(string name, string? otherName)
        {
            return string.Format(ErrorMessageString, name, otherName);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            object obj = validationContext.ObjectInstance;
            var first = (DateOnly?)obj.GetType()?.GetProperty(_param1)?.GetValue(validationContext.ObjectInstance, null);
            var second = (DateOnly?)obj.GetType()?.GetProperty(_param2)?.GetValue(validationContext.ObjectInstance, null);
            if (first != null && second != null)
            {
                if (first > second)
                {
                    var otherProperty = obj.GetType().GetProperty(_param2);
                    if (otherProperty != null)
                    {
                        DisplayAttribute? displayName = (DisplayAttribute?)GetCustomAttribute(otherProperty, typeof(DisplayAttribute));
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName, displayName?.GetName()));
                    }
                }
            }
            else if (second == null)
            {
                if (first > DateOnly.FromDateTime(DateTime.Now))
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName, "Data Atual"));
            }
            return ValidationResult.Success;
        }
    }
}