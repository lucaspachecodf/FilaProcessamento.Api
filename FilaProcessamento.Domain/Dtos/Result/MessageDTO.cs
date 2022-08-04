using FilaProcessamento.Domain.Validations.Notifications;
using System.Collections.Generic;

namespace FilaProcessamento.Domain.Dtos.Result
{
    public class MessageDTO
    {
        public bool Success { get; }
        public string Message { get; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public MessageDTO(bool success, string message, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Message = message;
            Notifications = notifications;
        }

        public MessageDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public MessageDTO(bool success, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Notifications = notifications;
        }

        public MessageDTO(bool success)
        {
            Success = success;
        }
    }
}
