using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Impulse : PhysicalUnit
    {
        public Impulse(double value, string dimension) : base(value, dimension)
        {
            ConverterForImpulse converter = new ConverterForImpulse();
            converter.ConvertToSi(dimension);
            Dimension = "N*s";
        }
        public Impulse() : base()
        {
            Dimension = "N*s";
        }

        public static Impulse operator +(Impulse impulse1, Impulse impulse2)
        {
            Impulse impulse = new Impulse();
            impulse.Value = impulse1.Value + impulse2.Value;
            return impulse;
        }

        public static Impulse operator -(Impulse impulse1, Impulse impulse2)
        {
            Impulse impulse = new Impulse();
            impulse.Value = impulse1.Value - impulse2.Value;
            return impulse;
        }

        public static NonDimensionalUnit operator /(Impulse impulse1, Impulse impulse2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = impulse1.Value / impulse2.Value;
            return nonDimensionalUnit;
        }

        public static Time operator /(Impulse impulse, Force force)
        {
            Time time = new Time();
            time.Value = impulse.Value / force.Value;
            return time;
        }

        public static Force operator /(Impulse impulse, Time time)
        {
            Force force = new Force();
            force.Value = impulse.Value / time.Value;
            return force;
        }
    }
}
