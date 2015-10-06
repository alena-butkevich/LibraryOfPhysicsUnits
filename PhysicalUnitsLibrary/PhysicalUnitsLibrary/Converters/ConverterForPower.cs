using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForPower
    {
        public void ConvertToSi(Power P, string dimension)
        {
            if (dimension != "W" || dimension != "kg*m^2/s^3")
            {
                if (dimension == "hp")
                {
                    P.Value *= 746;
                }
                if (dimension == "hp(M)")
                {
                    P.Value *= 735;
                }
                else
                {
                    throw new IncorrectDimensionOfPowerException();
                }
            }
        }
    }
}
