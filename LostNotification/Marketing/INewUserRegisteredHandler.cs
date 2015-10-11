using System;
using Messages.Registration.Commands;
using Messages.Registration.Events;
using NServiceBus;

namespace Marketing
{
    public class INewUserRegisteredHandler : IHandleMessages<INewUserRegistered>
    {
        public IBus Bus { get; set; }

        public void Handle(INewUserRegistered message)
        {
            Console.WriteLine($"Received notification that '{message.Email}' got registered (registration date: {message.RegistrationDateUtc.ToShortDateString()})");
            Console.WriteLine("Sending marketing stuff...");
            Bus.Send<SendNotification>(m =>
            {
                m.Email = message.Email;
                m.Title = "50% off!";
                m.Content = "As a new registrant you're entitled for 50% off out entire stock. Don't miss this opportunity.";
            });
        }
    }
}
