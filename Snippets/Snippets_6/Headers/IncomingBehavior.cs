﻿namespace Snippets6.Headers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NServiceBus;

    #region header-incoming-behavior
    public class IncomingBehavior : PhysicalMessageProcessingStageBehavior
    {
        public override async Task Invoke(Context context, Func<Task> next)
        {
            Dictionary<string, string> headers = context.Message.Headers;
            string nsbVersion = headers[Headers.NServiceBusVersion];
            string customHeader = headers["MyCustomHeader"];
            await next();
        }
    }
    #endregion
}
