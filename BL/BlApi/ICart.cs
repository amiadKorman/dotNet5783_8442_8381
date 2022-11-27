using BO;

namespace BlApi;

public interface ICart
{
    public Cart AddProduct(Cart cart, int productId);
    public Cart UpdateProductAmount(Cart cart, int productId, int amount);
    public void DoOrder(Cart cart);
}
