﻿using Framework.Domain.Events;
using Framework.Domain.ValueObjects;
using System;
using System.Linq;
using System.Text;

namespace Framework.Domain.Entieis
{
    //public abstract class BaseEntity<TId> 
    //{
    //    private readonly List<IEvent> _events;
    //    protected BaseEntity() => _events = new List<IEvent>();
    //    protected void HandleEvent(IEvent @event)
    //    {
    //        SetStateByEvent(@event);
    //        ValidateInvariants();
    //        Raise(@event);
    //    }
    //    protected void Raise(IEvent @event) => _events.Add(@event);
    //    public IEnumerable<IEvent> GetChanges() => _events.AsEnumerable();
    //    public void ClearChanges() => _events.Clear();
    //    protected abstract void ValidateInvariants();
    //    protected abstract void SetStateByEvent(IEvent @event);
    //}
    public abstract class BaseEntity<TId> where TId :IEquatable<TId>
    {
        public TId Id { get; protected set; }
        private Action<IEvent> _applier;
        public BaseEntity(Action<IEvent> applier)
        {
            _applier = applier;

        }
        protected BaseEntity() { }
        public void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            _applier(@event);
        }

        protected abstract void SetStateByEvent(IEvent @event);

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == default || other.Id == default)
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }


    }
}
