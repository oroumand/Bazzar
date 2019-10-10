using Framework.Domain.Events;
using System.Collections.Generic;

namespace Framework.Domain.Data
{
    public interface IEventSource
    {
        void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events) where TEvent : IEvent;
    }
}
