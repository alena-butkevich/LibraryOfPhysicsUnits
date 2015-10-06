using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfPowerException: Exception
    {
        public IncorrectDimensionOfPowerException()
        {
            Console.WriteLine("Incorrect dimension of power");
        }
    }
}
