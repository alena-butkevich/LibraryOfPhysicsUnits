using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Acceleration : PhysicalUnit
    {
        public Acceleration(double value, string dimension) : base(value, dimension)
        {
            ConverterForAcceleration converter = new ConverterForAcceleration();
            converter.ConvertToSi(this, dimension);
            Dimension = "m/s^2";
        }
        public Acceleration() : base()
        {
            Dimension = "m/s^2";
        }

        public static Acceleration operator +(Acceleration acceleration1, Acceleration acceleration2)
        {
            Acceleration acceleration = new Acceleration();
            acceleration.Value = acceleration1.Value + acceleration2.Value;
            return acceleration;
        }

        public static Acceleration operator -(Acceleration acceleration1, Acceleration acceleration2)
        {
            Acceleration acceleration = new Acceleration();
            acceleration.Value = acceleration1.Value - acceleration2.Value;
            return acceleration;
        }

        public static Speed operator *(Acceleration acceleration, Time time)
        {
            Speed speed = new Speed();
            speed.Value = acceleration.Value * time.Value;
            return speed;
        }
    }
}
