using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfDistanceException: Exception
    {
        public IncorrectDimensionOfDistanceException()
        {
             Console.WriteLine("Incorrect dimension of distance");
        }
    }
}
