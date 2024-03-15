using FoodApp.Areas.Item.Models;
using FoodApp.Areas.Restaurant.Models;
using FoodApp.Dal;
using FoodApp.Models;

namespace FoodApp.Bal;

public class ItemBal
{
    private ItemDal itemDal;

    public ItemBal()
    {
        itemDal = new ItemDal();
    }
    #region SelectAll

    public List<Item> SelectAllItems()
    {
        try
        {
            return itemDal.SelectAllItems();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Insert Item
    
    public bool InsertItem(Item item)
    {
        try
        {
            return itemDal.InsertItem(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    #endregion

    #region SelectItemByID
    
    public Item SelectItemByID(int ItemID)
    {
        try
        {
            return itemDal.SelectItemByID(ItemID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    #endregion
    #region Select Item By ID

    public bool UpdateItem(Item item)
    {
        try
        {
            return itemDal.UpdateItem(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
    
    #region Method : DeleteItemByID

    public bool DeleteItemByID(int ItemID)
    {
        try
        {
            return itemDal.DeleteItemByID(ItemID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
    
    #region GetDesignationsDLL

    public List<Restaurant> GetRestaurantDropdownList()
    {
        try
        {
            return itemDal.GetRestaurantDropdownList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    
    #region GetCategoryDropdownList

    public List<Category> GetCategoryDropdownList()
    {
        try
        {
            return itemDal.GetCategoryDropdownList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    
    

    
}