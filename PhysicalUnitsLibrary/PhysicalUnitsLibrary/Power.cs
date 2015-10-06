using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Power : PhysicalUnit
    {
        public Power(double value, string dimension) : base(value, dimension)
        {
            ConverterForPower converter = new ConverterForPower();
            converter.ConvertToSi(this, dimension);
            Dimension = "W";
        }
        public Power() : base()
        {
            Dimension = "W";
        }


        public static Power operator +(Power power1, Impulse power2)
        {
            Power power = new Power();
            power.Value = power1.Value + power2.Value;
            return power;
        }

        public static Power operator -(Power power1, Impulse power2)
        {
            Power power = new Power();
            power.Value = power1.Value - power2.Value;
            return power;
        }

        public static NonDimensionalUnit operator /(Power power1, Power power2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = power1.Value / power2.Value;
            return nonDimensionalUnit;
        }

        public static Speed operator /(Power power, Force force)
        {
            Speed speed = new Speed();
            speed.Value = power.Value / force.Value;
            return speed;
        }

        public static Force operator /(Power power, Speed speed)
        {
            Force force = new Force();
            force.Value = power.Value / speed.Value;
            return force;
        }
    }
}
