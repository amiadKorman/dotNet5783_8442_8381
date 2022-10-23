partial class Program
{
    private static void Main(string[] args)
    {
        Welcome8442();
        Welcome8381();
        Console.ReadKey();
    }

    static partial void Welcome8381();

    private static void Welcome8442()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("{0}, welcome to my first console application", userName);
    }
}