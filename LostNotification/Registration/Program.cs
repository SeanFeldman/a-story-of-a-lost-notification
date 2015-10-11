using System;
using Messages.Registration.Commands;
using NServiceBus;

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

            Console.WriteLine("Thank you for registration");
            Console.ReadLine();
        }

        private static void ConfigureBus()
        {
            var configuration = new BusConfiguration();
            configuration.UseTransport<MsmqTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<JsonSerializer>();
            Bus = NServiceBus.Bus.Create(configuration).Start();
        }
    }


//    class ConfigureErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
//    {
//        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
//        {
//            return new MessageForwardingInCaseOfFaultConfig
//            {
//                ErrorQueue = "error"
//            };
//        }
//    }
}
