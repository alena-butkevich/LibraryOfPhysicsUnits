using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfAccelerationException: Exception
    {
        public IncorrectDimensionOfAccelerationException()
        {
            Console.WriteLine("Incorrect dimension of acceleration");
        }
    }
}
