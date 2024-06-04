using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Conversions
{
    internal class LengthConversions
    {
        public class MetersToKilometers : IConversion
        {
            public int Id => 1;
            public string FromUnit => "meters";
            public string ToUnit => "kilometers";

            public double Convert(double value)
            {
                return value / 1000;
            }
        }

        public class MetersToCentimeters : IConversion
        {
            public int Id => 2;
            public string FromUnit => "meters";
            public string ToUnit => "centimeters";

            public double Convert(double value)
            {
                return value * 100;
            }
        }

        // Additional conversions can be added here
    }
}
