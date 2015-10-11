using Messages.Registration.Commands;
using NServiceBus;

namespace Notification
{
    public class SendNotificationHandler : IHandleMessages<SendNotification>
    {
        public void Handle(SendNotification message)
        {
            var notificationCenter = new NotificationCenter();
            notificationCenter.Notify(message.Email, message.Title, message.Content);
        }
    }
}