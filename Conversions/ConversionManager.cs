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
            // Method to find the first conversion in the _conversions list that matches the provided id. If no such conversion is found, it returns null.
            return _conversions.FirstOrDefault(c => c.Id == id);
        }
    }
}
