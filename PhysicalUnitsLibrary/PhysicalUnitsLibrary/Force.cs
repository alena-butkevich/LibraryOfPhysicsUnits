using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Force : PhysicalUnit
    {
        public Force(double value, string dimension) : base(value, dimension)
        {
            ConverterForForce converter = new ConverterForForce();
            converter.ConvertToSi(this, dimension);
            Dimension = "N (kg*m/s^2)";
        }
        public Force() : base()
        {
            Dimension = "N (kg*m/s^2)";
        }

        public static Force operator +(Force force1, Force force2)
        {
            Force force = new Force();
            force.Value = force1.Value + force2.Value;
            return force;
        }

        public static Force operator -(Force force1, Force force2)
        {
            Force force = new Force();
            force.Value = force1.Value - force2.Value;
            return force;
        }

        public static NonDimensionalUnit operator /(Force force1, Force force2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = force1.Value / force2.Value;
            return nonDimensionalUnit;
        }

        public static Impulse operator *(Time time, Force force)
        {
            Impulse impulse = new Impulse();
            impulse.Value = time.Value * force.Value;
            return impulse;
        }

        public static Power operator *(Force force, Speed speed)
        {
            Power power = new Power();
            power.Value = speed.Value * force.Value;
            return power;
        }

        public static Mass operator /(Force force, Acceleration acceleration)
        {
            Mass mass = new Mass();
            mass.Value = force.Value / acceleration.Value;
            return mass;
        }

        public static Acceleration operator /(Force force, Mass mass)
        {
            Acceleration acceleration = new Acceleration();
            acceleration.Value = force.Value / mass.Value;
            return acceleration;
        }
    }
}
