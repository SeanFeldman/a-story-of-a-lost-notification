using NServiceBus;

namespace Messages.Registration.Commands
{
    public class SendNotification : ICommand
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}