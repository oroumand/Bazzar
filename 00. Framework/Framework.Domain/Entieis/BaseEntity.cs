using Framework.Domain.Events;
using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Domain.Entieis
{
    public abstract class BaseEntity<TId> where TId : IEntityId, IEquatable<TId>
    {
        private readonly List<IEvent> _events;
        protected BaseEntity() => _events = new List<IEvent>();
        protected void Raise(IEvent @event) => _events.Add(@event);
        public IEnumerable<IEvent> GetChanges() => _events.AsEnumerable();
        public void ClearChanges() => _events.Clear();
        protected abstract void ValidateInvariants();
    }
}
