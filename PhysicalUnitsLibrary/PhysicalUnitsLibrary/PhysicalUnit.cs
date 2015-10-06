using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary
{
    abstract public class PhysicalUnit
    {
        private double value;
        public string dimension;
        public double Value { get; set; }
        public string Dimension { get; set; }

        public PhysicalUnit()
        {
           
        }

        public PhysicalUnit(double value, string dimension)
        {
            this.Dimension = dimension;
            this.Value = value;
        }

        public void Output()
        {
            Console.WriteLine(this.Value + " " + this.Dimension + " ");
        }
    }
}
