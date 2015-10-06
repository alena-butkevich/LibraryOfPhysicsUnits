using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary
{ 
    public class NonDimensionalUnit : PhysicalUnit
    {
        public NonDimensionalUnit(double value)
        {
            this.Value = value;
            this.Dimension = "";
        }

        public NonDimensionalUnit()
        {
            this.Dimension = "";
        }

        public static NonDimensionalUnit operator +(NonDimensionalUnit nonDimensionalUnit1, NonDimensionalUnit nonDimensionalUnit2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = nonDimensionalUnit1.Value + nonDimensionalUnit2.Value;
            return nonDimensionalUnit;
        }

        public static NonDimensionalUnit operator -(NonDimensionalUnit nonDimensionalUnit1, NonDimensionalUnit nonDimensionalUnit2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = nonDimensionalUnit1.Value - nonDimensionalUnit2.Value;
            return nonDimensionalUnit;
        }   

        public static NonDimensionalUnit operator /(NonDimensionalUnit distance1, NonDimensionalUnit distance2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = distance1.Value / distance2.Value;
            return nonDimensionalUnit;
        }

        public static NonDimensionalUnit operator *(NonDimensionalUnit distance1, NonDimensionalUnit distance2)
        {
            NonDimensionalUnit nonDimensionalUnit = new NonDimensionalUnit();
            nonDimensionalUnit.Value = distance1.Value * distance2.Value;
            return nonDimensionalUnit;
        }
    }
}
