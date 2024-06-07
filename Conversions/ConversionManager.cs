// Strategy object reference to Strategy interface and responsible for implementing different strategies.
using System.Collections.Generic;
using System.Linq;

namespace ConverterApp.Conversions
{
    public class ConversionManager
    {
        private readonly List<IConversion> _conversions = new List<IConversion>();

        // Adds a new conversion strategy
        public void RegisterConversion(IConversion conversion)
        {
            _conversions.Add(conversion);
        }

        // Retrieves a conversion strategy based on its unique identifier
        public IConversion GetConversion(int id)
        {
            return _conversions.FirstOrDefault(c => c.Id == id);
        }
    }
}
