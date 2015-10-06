using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Converters;

namespace PhysicalUnitsLibrary
{
    public class Momentum : PhysicalUnit
    {
        public Momentum(double value, string dimension) : base(value, dimension)
        {
            ConverterForMomentum converter = new ConverterForMomentum();
            converter.ConvertToSi(dimension);
            Dimension = "N*s";
        }
        public Momentum() : base()
        {
            Dimension = "N*s";
        }

        public static Momentum operator +(Momentum momentum1, Impulse momentum2)
        {
            Momentum momentum = new Momentum();
            momentum.Value = momentum1.Value + momentum2.Value;
            return momentum;
        }

        public static Momentum operator -(Momentum momentum1, Impulse momentum2)
        {
            Momentum momentum = new Momentum();
            momentum.Value = momentum1.Value - momentum2.Value;
            return momentum;
        }

        public static NonDimensionalUnit operator /(Momentum momentum1, Momentum momentum2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = momentum1.Value / momentum2.Value;
            return nonDimensionalUnit;
        }

        public static Mass operator /(Momentum momentum, Speed speed)
        {
            Mass mass = new Mass();
            mass.Value = momentum.Value / speed.Value;
            return mass;
        }

        public static Speed operator /(Momentum momentum, Mass mass)
        {
            Speed speed = new Speed();
            speed.Value = momentum.Value / mass.Value;
            return speed;
        }
    }
  }
