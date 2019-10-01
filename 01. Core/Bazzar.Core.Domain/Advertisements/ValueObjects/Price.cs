using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class Price : BaseValueObject<Price>
    {
        private readonly Rial _value;
        public static Price FromString(string value) => new Price(Rial.FromString(value));
        public static Price FromLong(long value) => new Price(Rial.FromLong(value));
        public Price(Rial rial)
        {
            if (rial < 1)
            {
                throw new ArgumentOutOfRangeException("مقدار قیمت کمتر از 1 ریال نمی‌تواند باشد", nameof(Price));
            }
            _value = rial;
        }
        public override int ObjectGetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool ObjectIsEqual(Price otherObject)
        {
            return _value == otherObject._value;
        }
        public static implicit operator long(Price price)=> price._value;
    }
}
