using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BiddingCreateVM
    {
        [Required(ErrorMessage = "A Descriçao da Licitação é obrigatória")]
        [StringLength(maximumLength: 200, MinimumLength = 10, ErrorMessage = "A Descrição da Licitação precisa ter entre 10 e 200 caracteres")]
        [DisplayName("Descrição")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Número da Licitação é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Número da Licitação deve ter no máximo 100 caracteres")]
        [DisplayName("Número")]
        public string Number { get; set; } = string.Empty;
    }
}