using System.Data;
using System.Data.Common;
using FoodApp.Areas.Item.Models;
using FoodApp.Areas.Restaurant.Models;
using FoodApp.Bal;
using FoodApp.BAL;
using FoodApp.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using NuGet.Configuration;

namespace FoodApp.Dal;

public class ItemDal : DAL_Helper
{
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;

    public ItemDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    #region Select All Item

    public List<Item> SelectAllItems()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectAllItems");
            _sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
            List<Item> list = new List<Item>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    Item item = new Item();
                    item.ItemID = Convert.ToInt32(dr["ItemID"]);
                    item.UserID = Convert.ToInt32(dr["UserID"]);
                    item.ItemName = dr["ItemName"].ToString();
                    item.ItemDescription = dr["ItemDescription"].ToString();
                    item.ItemPrice = Convert.ToInt32(dr["ItemPrice"]);
                    list.Add(item);
                }
            }

            return list;
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
            DbCommand dbcommand = _sqlDatabase.GetStoredProcCommand("InsertItem");
            _sqlDatabase.AddInParameter(dbcommand, "UserID", SqlDbType.Int, CV.UserID());
            _sqlDatabase.AddInParameter(dbcommand, "RestaurantID", SqlDbType.Int, item.RestaurantID);
            _sqlDatabase.AddInParameter(dbcommand, "CategoryID", SqlDbType.Int, 1
            );
            _sqlDatabase.AddInParameter(dbcommand, "@ItemName", SqlDbType.VarChar, item.ItemName);
            _sqlDatabase.AddInParameter(dbcommand, "@ItemDescription", SqlDbType.VarChar, item.ItemDescription);
            _sqlDatabase.AddInParameter(dbcommand, "@ItemPrice", SqlDbType.Int, item.ItemPrice);
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbcommand));
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
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("SelectItemByID");
            _sqlDatabase.AddInParameter(dbCommand, "ItemID", DbType.Int32, ItemID);
            _sqlDatabase.AddInParameter(dbCommand, "UserID", SqlDbType.Int, CV.UserID());

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
                        ItemPrice = Convert.ToInt32(dr["ItemPrice"]),
                        RestaurantName = dr["RestaurantName"].ToString(),
                        CategoryName = dr["CategoryName"].ToString(),
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

    #region update item

    public bool UpdateItem(Item item)
    {
        try
        {
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("UpdateItem");
            _sqlDatabase.AddInParameter(dbCommand, "ItemID", DbType.Int32, item.ItemID);
            _sqlDatabase.AddInParameter(dbCommand, "UserID", SqlDbType.Int, CV.UserID());

            _sqlDatabase.AddInParameter(dbCommand, "@ItemName", SqlDbType.VarChar, item.ItemName);
            _sqlDatabase.AddInParameter(dbCommand, "@ItemDescription", SqlDbType.VarChar,
                item.ItemDescription);
            _sqlDatabase.AddInParameter(dbCommand, "@ItemPrice", SqlDbType.VarChar,
                item.ItemPrice);
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbCommand));
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Delete Restaurant

    public bool DeleteItemByID(int ItemID)
    {
        try
        {
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand("DeleteItemByID");
            _sqlDatabase.AddInParameter(cmd, "@ItemID", SqlDbType.Int, ItemID);
            _sqlDatabase.AddInParameter(cmd, "@UserID", SqlDbType.Int, CV.UserID());
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(cmd));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region [GetRestaurantDropdownList]

    public List<Restaurant> GetRestaurantDropdownList()
    {
        List<Restaurant> restaurants = new List<Restaurant>();

        try
        {
            // Execute SQL command to fetch Staffs from the database
            using (DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("GetRestaurantDropdownList"))
            {
                _sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, CV.UserID());
                using (IDataReader dataReader = _sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.RestaurantID = Convert.ToInt32(dataReader["RestaurantID"]);
                        restaurant.RestaurantName = dataReader["RestaurantName"].ToString();
                        // Add more properties as needed

                        restaurants.Add(restaurant);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            // For simplicity, let's rethrow the exception
            throw;
        }

        return restaurants;
    }

    #endregion

    #region [GetCategoryDropdownList]

    public List<Category> GetCategoryDropdownList()
    {
        List<Category> categories = new List<Category>();

        try
        {
            // Execute SQL command to fetch Staffs from the database
            using (DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("GetCategoryDropdownList"))
            {
                _sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, CV.UserID());
                using (IDataReader dataReader = _sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        Category category = new Category();
                        category.CategoryID = Convert.ToInt32(dataReader["CategoryID"]);
                        category.CategoryName = dataReader["CategoryName"].ToString();
                        // Add more properties as needed

                        categories.Add(category);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            // For simplicity, let's rethrow the exception
            throw;
        }

        return categories;
    }

    #endregion
}