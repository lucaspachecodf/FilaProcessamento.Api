using FilaProcessamento.Domain.Validations.Contract;
using FilaProcessamento.Domain.Validations.Notifications;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilaProcessamento.Api.Models
{
    public class MoedaModel : Notifiable, IValidatable
    {
        public string Moeda { get; set; }
        [DataType(DataType.Date)]
        [JsonPropertyName("data_inicio")]
        public DateTime DataInicio { get; set; }
        [DataType(DataType.Date)]
        [JsonPropertyName("data_fim")]
        public DateTime DataFim { get; set; }

        public void Validate()
        {
            When(string.IsNullOrWhiteSpace(Moeda), "Moeda é obrigatório.");
        }
    }
}
