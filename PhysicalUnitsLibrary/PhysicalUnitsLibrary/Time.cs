using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary
{
    public class Time : PhysicalUnit
    {
        public Time(double value, string demension) : base(value, demension)
        {
            ConverterForTime converter = new ConverterForTime();
            converter.ConvertToSi(this, dimension);
            Dimension = "s";
        }
        public Time() : base()
        {
            Dimension = "s";
        }

        public static Time operator +(Time time1, Time time2)
        {
            Time time = new Time();
            time.Value = time1.Value + time2.Value;
            return time;
        }

        public static Time operator -(Time time1, Time time2)
        {
            Time time = new Time();
            time.Value = time1.Value - time2.Value;
            return time;
        }

        public static NonDimensionalUnit operator /(Time time1, Time time2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = time1.Value / time2.Value;
            return nonDimensionalUnit;
        }

        public static Distance operator *(Time time, Speed speed)
        {
            Distance distance = new Distance();
            distance.Value = time.Value * speed.Value;
            return distance;
        }

        public static Speed operator *(Time time, Acceleration acceleration)
        {
            Speed speed = new Speed();
            speed.Value = acceleration.Value * time.Value;
            return speed;
        }

        public static Impulse operator *(Force force, Time time)
        {
            Impulse impulse = new Impulse();
            impulse.Value = time.Value * force.Value;
            return impulse;
        }
    }
}
