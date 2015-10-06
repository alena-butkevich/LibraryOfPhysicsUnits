using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForSquare
    {
        public void ConvertToSi(Square S, string dimension)
        {
            if (dimension != "m^2")
            {
                if (dimension == "km^2")
                {
                    S.Value *= 1000000;
                }
                else if (dimension == "dm^2")
                {
                    S.Value /= 100;
                }
                else if (dimension == "cm^2")
                {
                    S.Value /= 10000;
                }
                else if (dimension == "mm^2")
                {
                    S.Value /= 1000000;
                }
                else
                {
                    throw new IncorrectDimensionOfSquareException();
                }
            }
        }
}
