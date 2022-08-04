using System.Collections.Generic;
using System.Linq;

namespace FilaProcessamento.Domain.Validations.Notifications
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() => _notifications = new List<Notification>();

        public void When(bool invalid, string error)
        {
            if (invalid)
                AddNotification(new Notification(error));
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        private void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool Invalid => _notifications.Any();

        public bool Valid => !Invalid;
    }
}
