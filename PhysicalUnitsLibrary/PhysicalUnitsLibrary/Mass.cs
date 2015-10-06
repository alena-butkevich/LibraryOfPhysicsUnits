using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Mass : PhysicalUnit
    {
        public Mass(double value, string dimension) : base(value, dimension)
        {
            ConverterForMass converter = new ConverterForMass();
            converter.ConvertToSi(this, dimension);
            Dimension = "kg";
        }
        public Mass() : base()
        {
            Dimension = "kg";
        }

        public static Mass operator +(Mass mass1, Mass mass2)
        {
            Mass mass = new Mass();
            mass.Value = mass1.Value + mass2.Value;
            return mass;
        }

        public static Mass operator -(Mass mass1, Mass mass2)
        {
            Mass mass = new Mass();
            mass.Value = mass1.Value - mass2.Value;
            return mass;
        }

        public static NonDimensionalUnit operator /(Mass mass1, Mass mass2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = mass1.Value / mass2.Value;
            return nonDimensionalUnit;
        }

        public static Momentum operator *(Mass mass, Speed speed)
        {
            Momentum momentum = new Momentum();
            momentum.Value = mass.Value * speed.Value;
            return momentum;
        }
    }
}
