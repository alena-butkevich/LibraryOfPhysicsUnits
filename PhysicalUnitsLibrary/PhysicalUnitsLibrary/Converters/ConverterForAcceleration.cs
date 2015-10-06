using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForAcceleration
    {
        public void ConvertToSi( Acceleration a, string dimension)
        {
            if (dimension != "m/s^2")
            {
                if (dimension == "Gal (cm/s^2)")
                {
                    a.Value *= 0.01;
                }
                else if (dimension == "ft/s^2")
                {
                    a.Value *= 0.304800;
                }
                else if (dimension == "g")
                {
                    a.Value *= 9.80665;
                }
                else
                {
                    throw new IncorrectDimensionOfAccelerationException();
                }
            }
        }
    }
}
