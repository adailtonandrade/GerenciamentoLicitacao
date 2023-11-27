using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum BiddingStatusEnum
    {
        [Description("Aberta")]
        [Display(Name ="Aberta")]
        Opened,
        [Description("Em Andamento")]
        [Display(Name = "Em Andamento")]
        InProgress,
        [Description("Fechada")]
        [Display(Name = "Fechada")]
        Closed
    }
}
