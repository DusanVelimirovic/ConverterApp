using System;
using System.Collections.Generic;

// Interface for conversion
public interface IConversion
{
    double Convert(double value);
    string Description { get; }
}

// Meters to Kilometers conversion
public class MetersToKilometers : IConversion
{
    public double Convert(double value) => value / 1000;
    public string Description => "Meters to Kilometers";
}

// Meters to Centimeters conversion
public class MetersToCentimeters : IConversion
{
    public double Convert(double value) => value * 100;
    public string Description => "Meters to Centimeters";
}

// Conversion Manager to handle conversions
public class ConversionManager
{
    private readonly Dictionary<int, IConversion> conversions = new();

    public ConversionManager()
    {
        // Register available conversions
        conversions.Add(1, new MetersToKilometers());
        conversions.Add(2, new MetersToCentimeters());
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Conversions menu:");
        foreach (var conversion in conversions)
        {
            Console.WriteLine($"{conversion.Key} - {conversion.Value.Description}");
        }
    }

    public bool TryGetConversion(int choice, out IConversion conversion) => conversions.TryGetValue(choice, out conversion);
}

// User interaction handler
public class UserInteraction
{
    public int GetUserMenuChoice()
    {
        Console.Write("Choose from above menu, enter the number of conversion: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }
        throw new FormatException("Invalid input. Please enter a valid number.");
    }

    public double GetUserConversionValue()
    {
        Console.Write("Enter value: ");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            return value;
        }
        throw new FormatException("Invalid input. Please enter a valid number.");
    }

    public bool PromptForExit()
    {
        Console.Write("Press Y to exit the converter or any other key to continue: ");
        return Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase);
    }
}

// Main application class
public class ConverterApplication
{
    private readonly ConversionManager conversionManager;
    private readonly UserInteraction userInteraction;

    public ConverterApplication()
    {
        conversionManager = new ConversionManager();
        userInteraction = new UserInteraction();
    }

    public void Run()
    {
        bool converterActive = true;

        while (converterActive)
        {
            try
            {
                conversionManager.DisplayMenu();
                int choice = userInteraction.GetUserMenuChoice();
                if (conversionManager.TryGetConversion(choice, out IConversion conversion))
                {
                    double value = userInteraction.GetUserConversionValue();
                    double result = conversion.Convert(value);
                    Console.WriteLine($"Convert {value} meters to {conversion.Description.Split(' ')[2]}");
                    Console.WriteLine($"{value} meters is {result} {conversion.Description.Split(' ')[2]}");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid menu choice.");
                }

                if (userInteraction.PromptForExit())
                {
                    converterActive = false;
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
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

// Entry point
class Program
{
    static void Main()
    {
        ConverterApplication app = new ConverterApplication();
        app.Run();
    }
}
