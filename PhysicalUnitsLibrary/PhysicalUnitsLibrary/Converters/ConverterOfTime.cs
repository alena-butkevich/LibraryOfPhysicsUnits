using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnitsLibrary.Converters
{
    public class ConverterOfTime
    {
        public void ConvertToSi(Power P, string dimension)
        {
            if (dimension != "s" || dimension != "sec")
            {
                if (dimension == "h")
                {
                    P.Value *= 3600;
                }
                if (dimension == "min")
                {
                    P.Value *= 60;
                }
                else
                {
                    throw new IncorrectDimensionOfPowerException();
                }
            }
        }
}
