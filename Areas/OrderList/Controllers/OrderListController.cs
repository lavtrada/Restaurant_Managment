using FoodApp.Bal;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.OrderList.Controllers;

[Area("OrderList")]
public class OrderListController : Controller
{
    private readonly OrderListBal orderListBal = new();

    #region Index Of Restaurant Wise Order

    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region Insert into orderlist
    [HttpPost]
    public IActionResult InsertOrder()
    {
            orderListBal.InsertInOrderList();
            return RedirectToAction("Index", "Home");
    }

    #endregion
}