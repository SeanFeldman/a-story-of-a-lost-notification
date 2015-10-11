using System;
using Messages.Registration.Commands;
using Messages.Registration.Events;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Registration
{
    class Program
    {
        private static IBus Bus;

        static void Main(string[] args)
        {
            Console.Write("Starting Registration (press Enter to configure bus and run code)");
            Console.ReadLine();
            ConfigureBus();

            Console.WriteLine("To register, please provide the following info:");
            Console.Write(" email address:");
            var email = Console.ReadLine();
            Console.Write(" password: ");
            var password = Console.ReadLine();

            Bus.Send<SendNotification>(m =>
            {
                m.Email = email;
                m.Title = "welcome";
                m.Content = "Great to have you with us!";
            });

            Bus.Publish<INewUserRegistered>(m =>
            {
                m.Email = email;
                m.RegistrationDateUtc = DateTime.UtcNow;
            });

            Console.WriteLine("Thank you for registration");
            Console.ReadLine();
        }

        private static void ConfigureBus()
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("Registration");
            configuration.UseTransport<MsmqTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<JsonSerializer>();
            Bus = NServiceBus.Bus.Create(configuration).Start();
        }
    }


    class ConfigureErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }

    class ConfigureMessageMappings : IProvideConfiguration<UnicastBusConfig>
    {
        public UnicastBusConfig GetConfiguration()
        {
            return new UnicastBusConfig
            {
                MessageEndpointMappings = new MessageEndpointMappingCollection
                {
                    new MessageEndpointMapping
                    {
                        AssemblyName = "Messages",
                        Namespace = "Messages.Registration.Commands",
                        Endpoint = "Notification"
                    }
                }
            };
        }
    }
}
