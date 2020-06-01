using System.Collections.Generic;

namespace LojaHiper.Core.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<NotificationMessage> GetNotifications();
        void Handle(NotificationMessage notification);
    }
}
