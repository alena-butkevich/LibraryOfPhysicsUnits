using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForDistance
    {
        public void ConvertToSi(Distance s, string dimension)
        {
            if (dimension != "m")
            {
                if (dimension == "km")
                {
                    s.Value *= 1000;
                }
                else if (dimension == "dm")
                {
                    s.Value /=10;
                }
                else if (dimension == "cm")
                {
                    s.Value /= 100;
                }
                else if (dimension == "mm")
                {
                    s.Value /= 1000;
                }
                else if (dimension == "mm")
                {
                    s.Value /= 1000;
                }
                else
                {
                    throw new IncorrectDimensionOfDistanceException();
                }
            }
        }
    }
}
