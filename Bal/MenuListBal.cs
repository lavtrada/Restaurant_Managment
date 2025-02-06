using FoodApp.Dal;
using FoodApp.Areas.MenuList.Models;
using FoodApp.Areas.Item.Models;
using FoodApp.Models;

namespace FoodApp.Bal;

public class MenuListBal
{
    private MenuListDal menuListDal;

    public MenuListBal()
    {
        menuListDal = new MenuListDal();
    }

    #region Select All MenuList

    public List<Item> SelectAllMenuItems()
    {
        try
        {
            List<Item> menuLists = menuListDal.SelectAllMenuItems();
            return menuLists;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Select By ID
    
    public Item SelectMenuByID(int ItemID)
    {
        try
        {
            return menuListDal.SelectMenuByID(ItemID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    #endregion
}