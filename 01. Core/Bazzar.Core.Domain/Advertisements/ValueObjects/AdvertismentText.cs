using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertismentText : BaseValueObject<AdvertismentText>
    {
        private readonly string _value;
        public AdvertismentText(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای متن آگهی مقدار لازم است", nameof(value));
            }
            _value = value;
        }
        public override int ObjectGetHashCode() => _value.GetHashCode();
        public override bool ObjectIsEqual(AdvertismentText otherObject) => _value == otherObject._value;

        public static implicit operator string(AdvertismentText advertismentText) => advertismentText._value;
    }
}
