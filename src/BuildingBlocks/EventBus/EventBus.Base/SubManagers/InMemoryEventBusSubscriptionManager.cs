using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.SubManagers
{
    public class InMemoryEventBusSubscriptionManager
    {
        private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;
        private readonly List<Type> _eventTypes;

        public event EventHandler<string> OnEventRemoved;
        public Func<string, string> eventNameGetter;
       
        public InMemoryEventBusSubscriptionManager(Dictionary<string, List<SubscriptionInfo>> handlers, List<Type> eventTypes, Func<string, string> eventNameGetter)
        {
            _handlers = handlers;
            _eventTypes = eventTypes;
            this.eventNameGetter = eventNameGetter;
        }

        public bool IsEmpty => !_handlers.Keys.Any();
        public void Clear() => _handlers.Clear();


        public Type GetEventTypeByName(string eventName)=>
        public string GetEventKey<T>()
        {
            string eventName = typeof(T).Name;
            return eventNameGetter(eventName);
        }
    }
}
