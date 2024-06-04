using System;
using ConverterApp.Conversions;
using ConverterApp.Utilities;
using static ConverterApp.Conversions.LengthConversions;

class Program
{
    static void Main(string[] args)
    {
        bool converterActive = true;

        var conversionManager = new ConversionManager();
        conversionManager.RegisterConversion(new MetersToKilometers());
        conversionManager.RegisterConversion(new MetersToCentimeters());

        while (converterActive)
        {
            try
            {
                // Display a conversion menu
                Console.WriteLine("Conversions menu: 1-Meters to Kilometers, 2-Meters to Centimeters... ");

                // Prompt user to choose from conversion menu
                Console.Write("Choose from above menu, enter the number of conversion: ");

                // Store user choice
                string keyMenu = Console.ReadLine();

                // Validate user menu input
                bool resultValidation = InputValidator.ValidateUserMenuInput(keyMenu);

                if (resultValidation)
                {
                    // Parse user input menu choice
                    int.TryParse(keyMenu, out int choice);

                    // Prompt user to enter value for conversion
                    Console.Write("Enter value: ");

                    // Store value for conversion
                    string value = Console.ReadLine();

                    // Validate user value for conversion
                    bool resultValueValidation = InputValidator.ValidateUserConversionValue(value);

                    if (resultValueValidation)
                    {
                        // Parse a value for conversion to double
                        double.TryParse(value, out double conversionValue);

                        // Perform conversion
                        var conversion = conversionManager.GetConversion(choice);
                        if (conversion != null)
                        {
                            double result = conversion.Convert(conversionValue);
                            Console.WriteLine($"{conversionValue} {conversion.FromUnit} is {result} {conversion.ToUnit}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid conversion choice.");
                        }

                        // Prompt user to choose if he wants to continue using the converter
                        Console.Write("Press Y to exit the converter or any other key to continue: ");
                        string exitInput = Console.ReadLine();
                        if (exitInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            converterActive = false;
                        }
                    }
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Input format is incorrect. Please enter valid numbers.");
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
