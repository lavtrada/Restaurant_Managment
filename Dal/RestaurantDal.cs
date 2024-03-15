using System.Data;
using System.Data.Common;
using FoodApp.Areas.Restaurant.Models;
using FoodApp.Bal;
using FoodApp.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal;

public class RestaurantDal : DAL_Helper
{
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;

    public RestaurantDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    #region SELECT ALL RESTAURANT

    public List<Restaurant> SelectAllRestaurants()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectAllRestaurants");
            List<Restaurant> list = new List<Restaurant>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    Restaurant restaurant = new Restaurant();
                    restaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    restaurant.RestaurantName = dr["RestaurantName"].ToString();
                    restaurant.RestaurantAddress = dr["RestaurantAddress"].ToString();
                    restaurant.RestaurantContact = dr["RestaurantContact"].ToString();
                    list.Add(restaurant);
                }
            }

            return list;
        }
        catch
        {
            return null;
        }
    }

    #endregion

    #region InsertRestaurant

    public bool InsertRestaurant(Restaurant restaurant)
    {
        try
        {
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("InsertRestaurant");
            _sqlDatabase.AddInParameter(dbCommand, "UserID", SqlDbType.Int, CV.UserID());

            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantName", SqlDbType.VarChar, restaurant.RestaurantName);
            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantAddress", SqlDbType.VarChar,
                restaurant.RestaurantAddress);
            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantContact", SqlDbType.VarChar,
                restaurant.RestaurantContact);
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbCommand));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region SelectRestaurantByID

    public Restaurant SelectRestaurantByID(int RestaurantID)
    {
        try
        {
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("SelectRestaurantByID");
            _sqlDatabase.AddInParameter(dbCommand, "RestaurantID", DbType.Int32, RestaurantID);
            Restaurant restaurant = null;
            using (IDataReader dr = _sqlDatabase.ExecuteReader(dbCommand))
            {
                if (dr.Read())
                {
                    restaurant = new Restaurant()
                    {
                        RestaurantID = Convert.ToInt32(dr["RestaurantID"]),
                        RestaurantName = dr["RestaurantName"].ToString(),
                        RestaurantAddress = dr["RestaurantAddress"].ToString(),
                        RestaurantContact = dr["RestaurantContact"].ToString(),
                    };
                }
            }

            return restaurant;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region update Restaurant

    public bool UpdateRestaurant(Restaurant restaurant)
    {
        try
        {
            DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("UpdateRestaurant");
            _sqlDatabase.AddInParameter(dbCommand, "RestaurantID", DbType.Int32, restaurant.RestaurantID);
            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantName", SqlDbType.VarChar, restaurant.RestaurantName);
            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantAddress", SqlDbType.VarChar,
                restaurant.RestaurantAddress);
            _sqlDatabase.AddInParameter(dbCommand, "@RestaurantContact", SqlDbType.VarChar,
                restaurant.RestaurantContact);
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

    public bool DeleteRestaurantByID(int RestaurantID)
    {
        try
        {
            
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand("DeleteRestaurantByID");
            _sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());

            _sqlDatabase.AddInParameter(cmd, "@RestaurantID", SqlDbType.Int, RestaurantID);
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(cmd));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}