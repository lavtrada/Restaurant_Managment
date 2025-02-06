using FoodApp.Bal;
using FoodApp.BAL;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.Cart.Controllers;
[Area("Cart")]
public class CartController:Controller
{
    private readonly CartBal cartBal = new();


    #region Select All

    public IActionResult Index()
    {
        var item = cartBal.SelectCartItem();
        return View(item);
    }

    #endregion

    #region SaveData
    
    [HttpPost]
    public IActionResult Save(Models.Cart itemCart)
    {
        
            cartBal.InsertIntoCart(itemCart);
            return RedirectToAction("Index");
    }
    #endregion
    
    #region Delete cart items

    public IActionResult Delete(int CartID)
    {
        cartBal.DeleteCartItems(CartID);
        return RedirectToAction("Index");
    }

    #endregion
}
