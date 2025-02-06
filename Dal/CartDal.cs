using System.Data;
using System.Data.Common;
using FoodApp.Areas.Cart.Models;
using FoodApp.Areas.Item.Models;
using FoodApp.Bal;
using FoodApp.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal;

public class CartDal : DAL_Helper
{
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;
    public CartDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    #region InsertItemIntoCart

    public bool InsertIntoCart(Cart item)
    {
        try
        {
            DbCommand dbcommand = _sqlDatabase.GetStoredProcCommand("InsertIntoCart");
            _sqlDatabase.AddInParameter(dbcommand, "UserID", SqlDbType.Int, CV.UserID());
            _sqlDatabase.AddInParameter(dbcommand, "@ItemID", SqlDbType.Int, item.ItemID);
            _sqlDatabase.AddInParameter(dbcommand,"@Quantity",SqlDbType.Int,item.Quantity);
            _sqlDatabase.AddInParameter(dbcommand,"@Address",SqlDbType.VarChar,item.Address);
            return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbcommand)); 
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
            SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectCartItem");
            _sqlDatabase.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
            List<Cart> list = new List<Cart>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    Cart item = new Cart();
                    item.CartID = Convert.ToInt32(dr["CartID"]);
                    item.ItemPrice = Convert.ToInt32(dr["ItemPrice"]);
                    item.ItemDescription = dr["ItemDescription"].ToString();
                    item.ItemName = dr["ItemName"].ToString();
                    item.RestaurantName = dr["RestaurantName"].ToString();
                    item.RestaurantAddress = dr["RestaurantAddress"].ToString();
                    item.Quantity = Convert.ToInt32(dr["Quantity"]);
                    item.Address = dr["Address"].ToString();
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

    #region Delete the items

    public bool DeleteCartItems(int CartID)
    {
        try
        {
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand("DeleteCartItems");
            _sqlDatabase.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);
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
    
}
