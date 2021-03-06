﻿namespace Core5.Monitoring
{
    using NServiceBus;

    class ServiceControlEventsConfig
    {
        ServiceControlEventsConfig(BusConfiguration busConfiguration)
        {
            #region ServiceControlEventsConfig

            busConfiguration.UseSerialization<JsonSerializer>();
            var conventions = busConfiguration.Conventions();
            conventions.DefiningEventsAs(
                type =>
                {
                    return typeof(IEvent).IsAssignableFrom(type) ||
                           // include ServiceControl events
                           type.Namespace != null &&
                           type.Namespace.StartsWith("ServiceControl.Contracts");
                });

            #endregion
        }
    }
}