namespace Dal;

internal class SafeInput
{
    /// <summary>
    /// Input an integer value in safe way. if there is an invalid input - try again.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static int IntegerInput(string message = "")
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out int num) ? num : IntegerInput("Invalid input. Please enter only an integer value:\n");
    }

    /// <summary>
    /// Input an integer value or null value.
    /// <param name="message"></param>
    /// <returns></returns>
    public static int? NullIntegerInput(string message = "")
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out int num) ? num : null;
    }

    /// <summary>
    /// Input a rational value in safe way. if there is an invalid input - try again.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static double DoubleInput(string message = "")
    {
        Console.Write(message);
        return double.TryParse(Console.ReadLine(), out double num) ? num : DoubleInput("Invalid input. Please enter only an integer value:\n");
    }

    /// <summary>
    /// // <summary>
    /// Input an rational value or null value.
    /// <param name="message"></param>
    /// <returns></returns>
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static double? NullDoubleInput(string message = "")
    {
        Console.Write(message);
        return double.TryParse(Console.ReadLine(), out double num) ? num : null;
    }

    /// <summary>
    /// Input a string in safe way. if there is an invalid input - try again.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string StringInput(string message = "")
    {
        Console.Write(message);
        string? My_str = Console.ReadLine();
        return string.IsNullOrWhiteSpace(My_str) ? StringInput("Invalid input. Please enter correct value:\n"): My_str ;
    }

    /// <summary>
    /// Input a string or empty string.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string NullStringInput(string message = "")
    {
        Console.Write(message);
        string? My_str = Console.ReadLine();
        return string.IsNullOrWhiteSpace(My_str) ? "" : My_str;
    }
}
