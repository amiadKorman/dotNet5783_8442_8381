using BlApi;

namespace BlImplementation;

/// <summary>
/// The class that implements the IBl interface.
/// </summary>
internal sealed class Bl : IBl
{
    public IOrder Order { get; } = new Order();
    public IProduct Product { get; } = new Product();
    public ICart Cart { get; } = new Cart();
    public ICustomer Customer { get; } = new Customer();

}
