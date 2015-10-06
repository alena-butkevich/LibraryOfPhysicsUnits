using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForMomentum
    {
        public void ConvertToSi (string dimension)
        {
            if (dimension != "N*s" || dimension != "kg*m/s")
            {
                throw new IncorrectDimensionOfMomentumException();
            }
        }
    }
}
