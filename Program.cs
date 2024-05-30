﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;

bool converterActive = true;

while (converterActive)
{
    // Display a conversion menu
    Console.WriteLine("Conversions menu: 1-Meters to Kilometers, 2-Meters to Centimeters... ");

    // Prompt user to choose from conversion menu
    Console.Write("Choose from above menu, enter the number of conversion: ");

    // Store user choose
    string keyMenu = Console.ReadLine();

    // Parse user choose
    int.TryParse(keyMenu, out int choice);

    // Prompt user to enter value for conversion
    Console.Write("Enter value: ");

    // Store value for conversion
    string value = Console.ReadLine();

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
    }

    // Prompt user to choose if he want to continue to use a convertor
    Console.Write("Press Y for exit a convertor or N to continue ");
    string exitTheGame = Console.ReadLine();
    bool userChoose = endOfConvertor(exitTheGame);
    if (!userChoose)
    {
        converterActive = false;
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