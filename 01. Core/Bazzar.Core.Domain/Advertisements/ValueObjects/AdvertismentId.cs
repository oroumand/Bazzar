using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertismentId : BaseValueObject<AdvertismentId>, IEntityId
    {
        private readonly Guid _value;
        public AdvertismentId(Guid value)
        {
            if (value == default)
                throw new ArgumentException("شناسه آگهی نمی‌تواند خالی باشد", nameof(value));
            _value = value;
        }
        public override int ObjectGetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool ObjectIsEqual(AdvertismentId otherObject)
        {
            return _value == otherObject._value;
        }
        public static implicit operator Guid(AdvertismentId advertismentId)=> advertismentId._value;
            
    }
}
