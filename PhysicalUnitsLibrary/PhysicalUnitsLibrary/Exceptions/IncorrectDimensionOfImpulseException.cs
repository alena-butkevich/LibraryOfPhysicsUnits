using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfImpulseException: Exception
    {
        public IncorrectDimensionOfImpulseException()
        {
            Console.WriteLine("Incorrect dimension of impulse");
        }
    }
}
