using FilaProcessamento.Domain.Validations.Contract;
using FilaProcessamento.Domain.Validations.Notifications;
using System;

namespace FilaProcessamento.Api.Models
{
    public class MoedaModel : Notifiable, IValidatable
    {
        public string Moeda { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public void Validate()
        {
            When(string.IsNullOrWhiteSpace(Moeda), "Moeda é obrigatório.");
        }
    }
}
