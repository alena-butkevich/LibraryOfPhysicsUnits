using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicalUnitsLibrary.Exceptions;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterForMass
    {
        public void ConvertToSi(Mass m, string dimension)
        {
            if (dimension != "kg")
            {
                if (dimension == "t")
                {
                    m.Value *= 1000;
                }
                else if (dimension == "sl")
                {
                    m.Value *= 14.6;
                }
                else if (dimension == "Ib")
                {
                    m.Value *= 0.45;
                }
                else if (dimension == "g")
                {
                    m.Value /= 1000;
                }
                else if (dimension == "mg")
                {
                    m.Value /= 1000000000;
                }
                else
                {
                    throw new IncorrectDimensionOfMassException();
                }
            }
        }
    }
}
