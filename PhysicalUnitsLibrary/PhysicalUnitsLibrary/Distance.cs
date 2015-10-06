using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Distance : PhysicalUnit
    {
        public Distance(double value, string dimension) : base(value, dimension)
        {
            ConverterForDistance converter = new ConverterForDistance();
            converter.ConvertToSi(this, dimension);
            Dimension = "m";
        }
        public Distance() : base()
        {
            Dimension = "m";
        }

        public static Distance operator +(Distance distance1, Distance distance2)
        {
            Distance distance = new Distance();
            distance.Value = distance1.Value + distance2.Value;
            return distance;
        }

        public static Distance operator -(Distance distance1, Distance distance2)
        {
            Distance distance = new Distance();
            distance.Value = distance1.Value - distance2.Value;
            return distance;
        }

        public static NonDimensionalUnit operator /(Distance distance1, Distance distance2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = distance1.Value / distance2.Value;
            return nonDimensionalUnit;
        }

        public static Time operator /(Distance distance, Speed speed)
        {
            Time time = new Time();
            time.Value = distance.Value / speed.Value;
            return time;
        }

        public static Speed operator /(Distance distance, Time time)
        {
            Speed speed = new Speed();
            speed.Value = distance.Value / time.Value;
            return speed;
        }

        public static Square operator *(Distance distance1, Distance distance2)
        {
            Square square = new Square();
            square.Value = distance1.Value * distance2.Value;
            return square;
        }
    }
}
