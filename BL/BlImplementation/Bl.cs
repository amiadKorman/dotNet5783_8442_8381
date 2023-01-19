using BlApi;

namespace BlImplementation;

internal sealed class Bl : IBl
{
    public IOrder Order { get; } = new Order();
    public IProduct Product { get; } = new Product();
    public ICart Cart { get; } = new Cart();
}
