using Framework.Domain.Events;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain.Entieis
{

    public abstract class BaseAggregateRoot<TId>
    {

        private readonly List<IEvent> _events;
        public TId Id { get; protected set; }
        protected BaseAggregateRoot() => _events = new List<IEvent>();
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            _events.Add(@event);
        }
        protected abstract void SetStateByEvent(IEvent @event);
        public IEnumerable<object> GetEvents() => _events.AsEnumerable();
        public void ClearEvents() => _events.Clear();
        protected abstract void ValidateInvariants();
    }
}
