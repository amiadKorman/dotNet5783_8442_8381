﻿namespace Dal;

class SafeInput
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

    public static string stringInput(string message = "")
    {
        Console.Write(message);
        string My_str= " ";
        return string.IsNullOrWhiteSpace(message) ? My_str : stringInput("Invalid input. Please enter value value:\n");
    }

}
