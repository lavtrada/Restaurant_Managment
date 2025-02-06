using FoodApp.Bal;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.MenuList.Controllers
{
    [Area("MenuList")]
    public class MenuListController:Controller
    {
        private readonly MenuListBal _menuListBal = new();

        #region Select All Menu

        public IActionResult Index()
        {
            var menulist = _menuListBal.SelectAllMenuItems();
            return View(menulist);
        }

        #endregion

        #region Details
        
        public IActionResult Details(int MenuListID)
        {
            var menuList = _menuListBal.SelectMenuByID(MenuListID);
            return View(menuList);
        }
        
        #endregion
    }
}