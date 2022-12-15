using BlApi;

namespace BlImplementation;

sealed public class Bl : IBl
{
    public IOrder Order { get; } = new Order();
    public IProduct Product { get; } = new Product();
    public ICart Cart { get; } = new Cart();
}
