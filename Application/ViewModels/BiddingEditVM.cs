using Domain.Enums;
using System.ComponentModel;

namespace Application.ViewModels
{
    public class BiddingEditVM : BiddingCreateVM
    {
        public int Id { get; set; }
        [DisplayName("Data de Abertura")]
        public DateTime OpeningDate { get; set; }
        public BiddingStatusEnum Status { get; set; }
    }
}
