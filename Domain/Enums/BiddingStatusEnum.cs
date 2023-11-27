using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum BiddingStatusEnum
    {
        [Description("Aberta")]
        Opened,
        [Description("Em Andamento")]
        InProgress,
        [Description("Fechada")]
        Closed
    }
}
