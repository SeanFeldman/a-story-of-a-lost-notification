using System;
using NServiceBus;

namespace Messages.Registration.Events
{
    public interface INewUserRegistered : IEvent
    {
        string Email { get; set; }
        DateTime RegistrationDateUtc { get; set; }
    }
}