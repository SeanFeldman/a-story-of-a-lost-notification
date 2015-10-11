using System;
using Messages.Registration.Events;
using NServiceBus;

namespace Marketing
{
    public class INewUserRegisteredHandler : IHandleMessages<INewUserRegistered>
    {
        public void Handle(INewUserRegistered message)
        {
            Console.WriteLine($"Received notification that '{message.Email}' got registered (registration date: {message.RegistrationDateUtc.ToShortDateString()})");
        }
    }
}
