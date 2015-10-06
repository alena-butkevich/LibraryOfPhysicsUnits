using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForForce
    {
        public void ConvertToSi(Force F, string dimension)
        {
            if (dimension != "N" || dimension != "kg*m/s^2")
            {
                if (dimension == "kp")
                {
                    F.Value *= 9.80665;
                }
                if (dimension == "kN")
                {
                    F.Value *= 1000;
                }
                else
                {
                    throw new IncorrectDimensionOfForceException();
                }
            }
        }
    }
}
