using BO;

namespace BlApi;

public interface ICart
{
    /// <summary>
    /// Add product to cart
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Cart Add(Cart cart, int productId);
    /// <summary>
    /// Update product amount in cart
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public Cart Update(Cart cart, int productId, int amount);
    /// <summary>
    /// Buy the cart and place order
    /// </summary>
    /// <param name="cart"></param>
    public void Buy(Cart cart);

    /// <summary>
    /// Adding customer details to log in
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <returns></returns>
    public Cart LogIn(BO.Cart cart, int ID, string name, string email, string address);
}
