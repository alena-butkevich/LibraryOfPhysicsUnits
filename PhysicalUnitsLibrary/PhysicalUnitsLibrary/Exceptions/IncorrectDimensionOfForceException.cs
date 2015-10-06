using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfForceException: Exception
    {
        public IncorrectDimensionOfForceException()
        {
            Console.WriteLine("Incorrect dimension of force");
        }
    }
}
