using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForSpeed
    {
        public void ConvertToSi(Speed v, string dimension)
        {
            if (dimension != "m/s" )
            {
                if (dimension == "km/h")
                {
                    v.Value *= 0.277778;
                }
                if (dimension == "mph")
                {
                    v.Value *= 0.44704;
                }
                if (dimension == "knot")
                {
                    v.Value *= 0.514444;
                }
                if (dimension == "ft/s")
                {
                    v.Value *= 0.3048;
                }

                else
                {
                    throw new IncorrectDimensionOfSpeedException();
                }
            }
        }
}
