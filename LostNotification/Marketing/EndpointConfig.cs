
namespace Marketing
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EndpointName("Marketing");
            configuration.UseTransport<MsmqTransport>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<JsonSerializer>();
        }
    }
}
