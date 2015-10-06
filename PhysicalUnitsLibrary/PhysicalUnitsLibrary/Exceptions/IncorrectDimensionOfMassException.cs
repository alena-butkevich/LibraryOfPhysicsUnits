using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfMassException: Exception
    {
        public IncorrectDimensionOfMassException()
        {
            Console.WriteLine("Incorrect dimension of mass");
        }
    }
}
