namespace BlApi;

/// <summary>
/// Interface for the business logic layer.
/// </summary>
public interface IBl
{
    public IProduct Product { get; }
    public IOrder Order { get; }
    public ICart Cart { get; }
}
