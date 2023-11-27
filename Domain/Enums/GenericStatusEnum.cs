using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Enums
{
    public enum GenericStatusEnum
    {
        [Description("Inativo")]
        [Display(Name = "Inativo")]
        Inactive = 0,
        [Description("Ativo")]
        [Display(Name = "Ativo")]
        Active = 1
    }
}
