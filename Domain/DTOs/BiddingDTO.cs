using Domain.Enums;
using Domain.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class BiddingDTO
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        [JsonPropertyName("Description")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Número")]
        [JsonPropertyName("Number")]
        public string Number { get; set; } = string.Empty;

        [DisplayName("Data de Abertura")]
        [JsonPropertyName("OpeningDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly OpeningDate { get; set; }

        [DisplayName("Status")]
        [JsonPropertyName("Status")]
        [JsonConverter(typeof(CustomStringEnumConverter))]
        public BiddingStatusEnum Status { get; set; }
    }
}
