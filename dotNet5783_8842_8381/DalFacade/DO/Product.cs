using static DO.Enums;

namespace DO;

/// <summary>
/// Strucure for Product
/// </summary>
public struct Product
{

    public int ID { get; set; }
    public string Name { get; set; }
    public double Praice { get; set; }
    public Category category { get; set; }
    public int InStock { get; set; }

   
}
