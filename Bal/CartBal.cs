using FoodApp.Areas.Cart.Models;
using FoodApp.Areas.Item.Models;
using FoodApp.Dal;

namespace FoodApp.Bal;

public class CartBal
{
    private CartDal cartDal;

    public CartBal()
    {
        cartDal = new CartDal();
    }

    #region Insert Item
    
    public bool InsertIntoCart(Cart cart)
    {
        try
        {
            return cartDal.InsertIntoCart(cart);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion

    #region Select All

    public List<Cart> SelectCartItem()
    {
        try
        {
            return cartDal.SelectCartItem();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Delete Cart items

    public bool DeleteCartItems(int CartID)
    {
        try
        {
            return cartDal.DeleteCartItems(CartID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    
}