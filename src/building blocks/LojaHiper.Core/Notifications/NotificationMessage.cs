﻿namespace LojaHiper.Core.Notifications
{
    public class NotificationMessage
    {
        public NotificationMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
