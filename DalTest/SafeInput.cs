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
        int num = 0;
        return int.TryParse(Console.ReadLine(), out num) ? num : IntegerInput("Invalid input. Please enter only an integer value:\n");
    }

    /// <summary>
    /// Input a rational value in safe way. if there is an invalid input - try again.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static double DoubleInput(string message = "")
    {
        Console.Write(message);
        double num = 0.0;
        return double.TryParse(Console.ReadLine(), out num) ? num : DoubleInput("Invalid input. Please enter only an integer value:\n");
    }

    public static string StringInput(string message = "")
    {
        Console.Write(message);
        string My_str = Console.ReadLine();
        return string.IsNullOrWhiteSpace(My_str) ? StringInput("Invalid input. Please enter value value:\n"): My_str ;
    }

}
