﻿using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.FileBasedRouting;

class Program
{

    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        Console.Title = "Samples.FileBasedRouting.Billing";
        var endpointConfiguration = new EndpointConfiguration("Samples.FileBasedRouting.Billing");
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.UsePersistence<LearningPersistence>();
        var transport = endpointConfiguration.UseTransport<LearningTransport>();
        var routing = transport.Routing();
        routing.UseFileBasedRouting(@"..\..\..\endpoints.xml");

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}