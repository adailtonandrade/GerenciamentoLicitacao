using Domain.Enums;
using Domain.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BiddingEditVM : BiddingCreateVM
    {
        public int Id { get; set; }
        [DisplayName("Data de Abertura")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [CompareDataAttribute("OpeningDate", "", ErrorMessage = "A {0} não pode ser maior que a {1}")]
        public DateOnly OpeningDate { get; set; }
        public BiddingStatusEnum Status { get; set; }
    }
}
