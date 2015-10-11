namespace Notification
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<MsmqTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<JsonSerializer>();
        }
    }
}
