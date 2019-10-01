using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertismentTitle : BaseValueObject<AdvertismentTitle>
    {

        private readonly string _value;
        public AdvertismentTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای عنوان آگهی مقدار لازم است", nameof(value));
            }
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("عنوان آگهی نباید بیش از 100 کاراکتر باشد", nameof(value));
            }
            _value = value;
        }        
        public override int ObjectGetHashCode() => _value.GetHashCode();
        public override bool ObjectIsEqual(AdvertismentTitle otherObject) => _value == otherObject._value;

        public static implicit operator string(AdvertismentTitle advertismentTitle) => advertismentTitle._value;
    }
}
