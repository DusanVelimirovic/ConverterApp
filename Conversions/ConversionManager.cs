using System.Collections.Generic;
using System.Linq;

namespace ConverterApp.Conversions
{
    public class ConversionManager
    {
        private readonly List<IConversion> _conversions = new List<IConversion>();

        public void RegisterConversion(IConversion conversion)
        {
            _conversions.Add(conversion);
        }

        public IConversion GetConversion(int id)
        {
            return _conversions.FirstOrDefault(c => c.Id == id);
        }
    }
}
