using System.Data;
using System.Data.Common;
using FoodApp.Areas.Cart.Models;
using FoodApp.Areas.Item.Models;
using FoodApp.Areas.OrderList.Models;
using FoodApp.Bal;
using FoodApp.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal;

public class OrderListDal : DAL_Helper
{
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;

    public OrderListDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    #region Restaurant Wise OrderList

    /*
    public List<OrderList> SelectAllOrders()
    {
        try
        {
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand("SelectAllOrders");
            // _sqlDatabase.AddInParameter(cmd,"RestaurantId",SqlDbType.Int,CV.);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }*/

    #endregion

    // #region Select All OrderList
    //
    // public List<Item> SelectAllMenuItems()
    // {
    //     try
    //     {
    //         SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
    //         DbCommand cmd = sqlDatabase.GetStoredProcCommand("SelectAllMenuItems"); 
    //         List<Item> menuLists = new List<Item>();
    //         using (IDataReader dr = sqlDatabase.ExecuteReader(cmd))
    //         {
    //             while (dr.Read())
    //             {
    //                 Item menuList = new Item();
    //            
    //                 menuList.ItemID = Convert.ToInt16(dr["ItemID"].ToString()); 
    //                 menuList.ItemName = dr["ItemName"].ToString();
    //                 menuList.ItemPrice = Convert.ToInt16(dr["ItemPrice"].ToString());
    //                 menuList.ItemDescription = dr["ItemDescription"].ToString();
    //                 menuLists.Add(menuList);
    //             }
    //         }
    //
    //         return menuLists;
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }

    // #endregion

    #region Insert into Orderlist

    public bool InsertInOrderList()
    {
        try
        {
            CartDal _cartbl = new CartDal();
            bool inserted = false;

            foreach (var VARIABLE in _cartbl.SelectCartItem())
            {
                DbCommand dbcommand = _sqlDatabase.GetStoredProcCommand("InsertInOrderList");
                _sqlDatabase.AddInParameter(dbcommand, "UserID", SqlDbType.Int, CV.UserID());
                _sqlDatabase.AddInParameter(dbcommand, "CartID", SqlDbType.Int, VARIABLE.CartID);
                inserted = Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbcommand));
            }

            return inserted;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}