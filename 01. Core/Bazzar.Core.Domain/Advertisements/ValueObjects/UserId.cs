using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class UserId:BaseValueObject<UserId>
    {
        private readonly Guid _value;
        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentException("شناسه کاربر نمی‌تواند خالی باشد", nameof(value));
            _value = value;
        }
        public override int ObjectGetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool ObjectIsEqual(UserId otherObject)
        {
            return _value == otherObject._value;
        }
        public static implicit operator Guid(UserId userId) => userId._value;
    }
}
