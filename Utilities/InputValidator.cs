namespace ConverterApp.Utilities
{
    public static class InputValidator
    {
        public static bool ValidateUserMenuInput(string menu)
        {
            if (!int.TryParse(menu, out int choice) || choice < 1)
            {
                Console.Write("Invalid input. Please enter a valid number from menu: ");
                return false;
            }
            return true;
        }

        public static bool ValidateUserConversionValue(string value)
        {
            if (!double.TryParse(value, out double conversionValue) || conversionValue < 0 || conversionValue > double.MaxValue || conversionValue < double.MinValue)
            {
                Console.Write("Invalid input. Please enter a valid number");
                return false;
            }
            return true;
        }
    }
}
