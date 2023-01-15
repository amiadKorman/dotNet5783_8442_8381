using BlApi;

namespace BlImplementation;

internal class Cart : ICart
{
    private DalApi.IDal dal = new Dal.DalList();

    /// <summary>
    /// Add product to cart, for catalog and product details screens
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlOutOfStockException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
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
                cart.Items?.Add(new BO.OrderItem
                {
                    ID = 0,
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
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("Product does not exist", ex);
        };
    }

    /// <summary>
    /// Update the total prce of the cart
    /// </summary>
    /// <param name="cart"></param>
    private void UpdateTotalPrice(BO.Cart cart) => cart.TotalPrice = cart.Items?.Sum(c => c.Price * c.Amount) ?? 0;

    /// <summary>
    /// Buying all the products in the cart, for cart or complete order screens
    /// </summary>
    /// <param name="cart"></param>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlOutOfStockException"></exception>
    public void Buy(BO.Cart cart)
    {
        try
        {
            dal.Customer.GetById(cart.CustomerID);

            if (cart.Items == null || cart.Items?.Count == 0)
            {
                throw new BO.BlInvalidFieldException("There is no items to buy in the cart!");
            }
            // check if all items in cart are in stock
            foreach (var item in cart.Items)
            {
                //check if product exist
                DO.Product product = dal.Product.GetById(item.ProductID);
                if (item.Amount <= 0)
                    throw new BO.BlInvalidFieldException("Amount of item can't be zero or negative");
                if (item.Amount > product.InStock)
                    throw new BO.BlOutOfStockException($"The Product {product.Name} does not have enough in stock!");
            }
            //create new order
            DO.Order order = new()
            {
                CustomerID = cart.CustomerID,
                OrderDate = DateTime.Now
            };
            int orderID = dal.Order.Add(order);
            //try to add order items and update products amount in database
            foreach (var item in cart.Items)
            {
                DO.OrderItem orderItem = new()
                {
                    ProductID = item.ProductID,
                    OrderID = orderID,
                    Price = item.Price,
                    Amount = item.Amount,
                };
                int orderItemID = dal.OrderItem.Add(orderItem);
                DO.Product product = dal.Product.GetById(item.ProductID);
                product.InStock -= item.Amount;
                dal.Product.Update(product);
            }
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlInvalidFieldException("Entity does not exist", ex);
        }
    }

    /// <summary>
    /// Update amount of cart product, for cart screen
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlInvalidFieldException"></exception>
    /// <exception cref="BO.BlDoesNotExistException"></exception>
    /// <exception cref="BO.BlOutOfStockException"></exception>
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
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("product does not exist", ex);
        };

        var item = ProductInCart(cart, productId) ?? throw new BO.BlDoesNotExistException("product does not exist in cart");
        if (amount == 0)
        {
            //Delete item from the cart
            cart.Items?.RemoveAll(oi => oi.ID == product.ID);
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

    /// <summary>
    /// Returns order item for product in cart
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    private BO.OrderItem? ProductInCart(BO.Cart cart, int productID) => cart.Items?.Find(oi => oi.ID == productID);

    /// <summary>
    /// Adding customer details to log in
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="customer"></param>
    /// <returns></returns>
    /// <exception cref="BO.BlFailedException"></exception>
    public BO.Cart LogIn(BO.Cart cart, DO.Customer customer)
    {
        try
        {
            dal.Customer.Add(customer);
            cart.CustomerID = customer.ID;
            return cart;
        }
        catch(DO.DalAlreadyExistsException ex)
        {
            DO.Customer cust = dal.Customer.GetById(customer.ID);
            if (cust.Name == customer.Name && cust.Address == customer.Address && cust.Email == customer.Email)
            {
                cart.CustomerID = customer.ID;
                return cart;
            }
            throw new BO.BlFailedException("This ID is already taken!", ex);
        }
    }
}
