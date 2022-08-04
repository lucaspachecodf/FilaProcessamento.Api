namespace FilaProcessamento.Domain.Validations.Notifications
{
    public sealed class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
