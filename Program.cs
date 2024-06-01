// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;

bool converterActive = true;

while (converterActive)
{
    try
    {
        // Display a conversion menu
        Console.WriteLine("Conversions menu: 1-Meters to Kilometers, 2-Meters to Centimeters... ");

    // Prompt user to choose from conversion menu
    Console.Write("Choose from above menu, enter the number of conversion: ");

    // Store user choose
    string keyMenu = Console.ReadLine();

    // Validate user menu input
    bool resultValidation = ValidateUserMenuInput(keyMenu);

    if (resultValidation) {

        // Parse user input menu choice

        int.TryParse(keyMenu, out int choice);

        // Prompt user to enter value for conversion
        Console.Write("Enter value: ");

        // Store value for conversion
        string value = Console.ReadLine();

        // Validate user value for conversion
        bool resultValueValidation = ValidateUserConversionValue(value);

        if (resultValueValidation)
        {
            // Parse a value for conversion to double
            double.TryParse(value, out double conversionValue);


            // Controle structure based on user choice
            double result = 0; // Initial value

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Convert " + conversionValue + " meters to kilometers");
                    result = ConvertMetersToKilometers(conversionValue);
                    Console.WriteLine(conversionValue + " meters is " + result + " kilometers");
                    break;
                case 2:
                    Console.WriteLine("Convert " + conversionValue + " meters to centimeters");
                    result = ConvertMetersToCentimeters(conversionValue);
                    Console.WriteLine(conversionValue + " meters is " + result + " centimeters");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid menu choice.");
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

// Logic for converting meters to kilometers
static double ConvertMetersToKilometers(double meters)
{
    return meters / 1000;
}

// Logic for converting meters to centimeters
static double ConvertMetersToCentimeters(double meters)
{
    return meters * 100;
}

// Shut down convertor
static bool endOfConvertor(string stopConvertor)
{
    if (stopConvertor == "Y")
    {
        return false; // or any appropriate logic
    }
    return true; // assuming the game continues if the input is not "Y"
}

// Validate user menu input
static bool ValidateUserMenuInput(string menu)
{
    if (!int.TryParse(menu, out int choice) || choice < 0)
    {
        Console.Write("Invalid input. Please enter a valid number from meny: ");
        return false;
    }
    return true;
}

// Validate user value for conversion
static bool ValidateUserConversionValue(string value)
{
    if (!double.TryParse(value, out double conversionValue) || conversionValue < 0 || conversionValue > double.MaxValue || conversionValue < double.MinValue)
    {
        Console.Write("Invalid input. Please enter a valid number");
        return false;
    }
    return true;
}