using System;
using Messages.Registration.Commands;
using NServiceBus;

namespace Notification
{
    public class SendNotificationHandler : IHandleMessages<SendNotification>
    {
        public void Handle(SendNotification message)
        {
            Console.WriteLine($"Sending notification to {message.Email} with title `{message.Title}`");
            var notificationCenter = new NotificationCenter();
            notificationCenter.Notify(message.Email, message.Title, message.Content);
        }
    }
}