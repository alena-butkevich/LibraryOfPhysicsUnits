using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Exceptions
{
    public class IncorrectDimensionOfMomentumException: Exception
    {
        public IncorrectDimensionOfMomentumException()
        {
            Console.WriteLine("Incorrect dimension of momentum");
        }
    }
}
