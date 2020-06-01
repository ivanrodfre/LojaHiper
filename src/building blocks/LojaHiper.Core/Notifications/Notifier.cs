using System.Collections.Generic;
using System.Linq;

namespace LojaHiper.Core.Notifications
{
    public class Notifier : INotifier
    {

        private List<NotificationMessage> _notifications;

        public Notifier()
        {
            _notifications = new List<NotificationMessage>();
        }

        public void Handle(NotificationMessage notification)
        {
            _notifications.Add(notification);
        }

        public List<NotificationMessage> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
