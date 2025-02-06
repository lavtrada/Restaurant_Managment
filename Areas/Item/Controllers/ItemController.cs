using FoodApp.Bal;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.Item.Controllers
{
    [Area("Item")]
    public class ItemController : Controller
    {
        private readonly ItemBal _itemBal = new();
        
        #region Sellect_All_item

        public IActionResult Index()
        {
            var item = _itemBal.SelectAllItems();
            return View(item);
        }

        #endregion

        public IActionResult Add_Edit(int ItemID)
        {
            ViewBag.RestorantList =_itemBal.GetRestaurantDropdownList();
            ViewBag.CategoryList =_itemBal.GetCategoryDropdownList();

            if (ItemID != 0)
            {
                return View("Add_Edit", _itemBal.SelectItemByID(ItemID));
            }
            else
            {
                return View("Add_Edit");
            }
        }
        
        #region SaveData

        [HttpPost]
        public IActionResult Save(Models.Item item)
        {
            if (item.ItemID == 0)
            {
                _itemBal.InsertItem(item);
            }
            else
            {
                _itemBal.UpdateItem(item);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Item

        public IActionResult Delete(int ItemID)
        {
            _itemBal.DeleteItemByID(ItemID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Details of Item

        public IActionResult Details(int ItemID)
        {
            var item = _itemBal.SelectItemByID(ItemID);
            // if (inquiry = null)
            // {
            //     return null;
            // }

            return View(item);
        }

        #endregion

    }
}