using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class Rial
    {
        private readonly long _value;
        public static Rial FromString(string value) => new Rial(long.Parse(value));
        public static Rial FromLong(long value) => new Rial(value);
        protected Rial(long value)
        {
            _value = value;
        }
        public Rial Add(Rial rial)
        {
            return new Rial(rial._value + _value);
        }
        public Rial Subtract(Rial rial)
        {
            return new Rial(rial._value + _value);
        }

        public static Rial operator +(Rial leftSide, Rial rightSide)
        {
            return leftSide.Add(rightSide);
        }
        public static Rial operator -(Rial leftSide, Rial rightSide)
        {
            return leftSide.Subtract(rightSide);
        }

        public static implicit operator long(Rial rial) => rial._value;
    }
}
