using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Speed : PhysicalUnit
    {
        public Speed(double value, string demension) : base(value, demension)
        {
            ConverterForSpeed converter = new ConverterForSpeed();
            converter.ConvertToSi(this, dimension);
            Dimension = "m/s";
        }
        public Speed() : base()
        {
            Dimension = "m/s";
        }
        
        public static Speed operator +(Speed speed1, Speed speed2)
        {
            Speed speed = new Speed();
            speed.Value = speed1.Value + speed2.Value;
            return speed;
        }

        public static Speed operator -(Speed speed1, Speed speed2)
        {
            Speed speed = new Speed();
            speed.Value = speed1.Value - speed2.Value;
            return speed;
        }

        public static NonDimensionalUnit operator /(Speed speed1, Speed speed2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = speed1.Value / speed2.Value;
            return nonDimensionalUnit;
        }

        public static Distance operator *(Speed speed, Time time)
        {
            Distance distance = new Distance();
            distance.Value = time.Value * speed.Value;
            return distance;
        }

        public static Acceleration operator /(Speed speed, Time time)
        {
            Acceleration acceleration = new Acceleration();
            acceleration.Value = speed.Value / time.Value;
            return acceleration;
        }

        public static Time operator /(Speed speed, Acceleration acceleration)
        {
            Time time = new Time();
            time.Value = speed.Value / acceleration.Value;
            return time;
        }

        public static Momentum operator *(Speed speed, Mass mass)
        {
            Momentum momentum = new Momentum();
            momentum.Value = mass.Value * speed.Value;
            return momentum;
        }

        public static Power operator *(Speed speed, Force force)
        {
            Power power = new Power();
            power.Value = speed.Value * force.Value;
            return power;
        }
    }
}
