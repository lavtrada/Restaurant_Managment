using System.Data;
using System.Data.Common;
using FoodApp.Areas.Item.Models;
using FoodApp.Areas.MenuList.Models;
using FoodApp.Areas.MenuList.Models;
using FoodApp.Bal;
using FoodApp.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal;

public class MenuListDal : DAL_Helper
{
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;

    public MenuListDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    #region Select All MenuList

    public List<Item> SelectAllMenuItems()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectAllMenuItems"); 
            List<Item> menuLists = new List<Item>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    Item menuList = new Item();
               
                    menuList.ItemID = Convert.ToInt16(dr["ItemID"].ToString()); 
                    menuList.ItemName = dr["ItemName"].ToString();
                    menuList.ItemPrice = Convert.ToInt64(dr["ItemPrice"].ToString());
                    menuList.ItemDescription = dr["ItemDescription"].ToString();
                    menuLists.Add(menuList);
                }
            }

            return menuLists;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region SelectByID

    public Item SelectMenuByID(int ItemID)
    {
        try
        {
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("SelectMenuByID");
            _sqlDatabase.AddInParameter(dbCommand, "ItemID", DbType.Int32, ItemID);
            Item item = null;

            using (IDataReader dr = _sqlDatabase.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    item = new Item()
                    {
                        ItemID = Convert.ToInt32(dr["ItemID"]),
                        ItemName = dr["ItemName"].ToString(),
                        ItemDescription = dr["ItemDescription"].ToString(),
                        ItemPrice = Convert.ToInt64(dr["ItemPrice"]),
                        RestaurantName = dr["RestaurantName"].ToString(),
                        // CategoryName = dr["CategoryName"].ToString(),
                        RestaurantAddress = dr["RestaurantAddress"].ToString(),
                    };
                }
            }

            return item;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    #endregion
}