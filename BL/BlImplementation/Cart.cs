using BlApi;

namespace BlImplementation;

internal class Cart : ICart
{
    private DalApi.IDal dal = new Dal.DalList();
    internal class Config
    {
        private const int startItemsNumber = 10000;
        private static int ItemID = startItemsNumber;
        internal static int NextItemID { get => ItemID++; }
    }
   
public BO.Cart Add(BO.Cart cart, int productId)
    {
        //check if the validation of the given product ID
        if (productId < 100000 || productId >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");

        try
        {
            //check if the product exist
            DO.Product product = dal.Product.GetById(productId);
            //check if the product in stock
            if (product.InStock == 0)
                throw new BO.BlOutOfStockException($"The Product {product.Name} is out of stock!");

            //check if product already in the cart or not
            var item = ProductInCart(cart, productId);
            if (item == null)
            {
                cart.Items?.Append(new BO.OrderItem
                {
                    ID = Config.NextItemID,
                    ProductID = productId,
                    Name = product.Name,
                    Price = product.Price,
                    Amount = 1,
                    TotalPrice = product.Price
                });
            }
            else
            {
                item.Amount += 1;
                item.TotalPrice = product.Price * item.Amount;
            }
            UpdateTotalPrice(cart);
            return cart;
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        };
    }

    private void UpdateTotalPrice(BO.Cart cart) => cart.TotalPrice = cart.Items?.Sum(c => c.Price * c.Amount) ?? 0;

    public void Buy(BO.Cart cart)
    {
        throw new NotImplementedException();
    }

    public BO.Cart Update(BO.Cart cart, int productId, int amount)
    {
        //check if the validation of the given product ID
        if (productId < 100000 || productId >= 1000000)
            throw new BO.BlInvalidFieldException("Product ID must be between 100000 to 1000000");
        if (amount < 0)
            throw new BO.BlInvalidFieldException("Amount must be non-negative");

        DO.Product product;
        try
        {
            //check if the product exist
            product = dal.Product.GetById(productId);
            
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException(ex.Message);
        };

        var item = ProductInCart(cart, productId) ?? throw new BO.BlDoesNotExistException("product does not exist in cart");
        if (amount == 0)
        {
            //Delete item from the cart
            cart.Items = cart.Items?.Where(oi => oi.ID != product.ID);
        }
        else if (item.Amount != amount)
        {
            if (product.InStock < item.Amount + amount)
                throw new BO.BlOutOfStockException($"The Product {product.Name} does not have enough in stock!");

            item.Amount = amount;
            item.TotalPrice = item.Price * item.Amount;
        }
        return cart;
    }

    private BO.OrderItem? ProductInCart(BO.Cart cart, int productID)
    {
        return cart.Items?.FirstOrDefault(oi => oi.ID == productID);
    }
}
