using EventBus.Base.Abstraction;
using EventBus.Base.SubManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public class BaseEventBus : IEventBus
    {
        private readonly IServiceProvider ServiceProvider;
        private readonly IEventBusSubscriptionManager SubsManager;

        private EventBusConfig eventBusConfig;

        public BaseEventBus(EventBusConfig config, IServiceProvider serviceProvider)
        {
            eventBusConfig = config;
            ServiceProvider = serviceProvider;
            SubsManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
        }

        public virtual string ProcessEventName(string eventName)
        {
            if (eventBusConfig.DeleteEventPrefix)
                eventName = eventName.TrimStart(eventBusConfig.EventNamePrefix.ToArray());
            if(eventBusConfig.DeleteEventSuffix)
                eventName = eventName.TrimEnd(eventBusConfig.EventNameSuffix.ToArray());
            return eventName;

        }

        public virtual string GetSubName(string eventName)
        {
            return $"{eventBusConfig.SubscriberClientAppName}.{ProcessEventName(eventName)}";
        }

        public virtual void Dispose()
        {
            eventBusConfig = null;
        }

        public Task<bool> ProcessEvent(string eventName, string message)
        {
            eventName = ProcessEventName(eventName);
            var processed = false;

            if (SubsManager.HasSubscriptionsInformation(eventName))
            {
                var subscriptions = SubsManager.GetHandlersForEvent(eventName);
            }
        }


    }
}
