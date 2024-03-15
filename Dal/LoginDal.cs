using System.Data;
using System.Data.Common;
using FoodApp.Areas.Auth.Models;
using FoodApp.Bal;
using FoodApp.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal
{
    public class LoginDal : DAL_Helper
    {


    private static SqlDatabase _sqlDatabase;

    public LoginDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }

    public Admin PR_User_Login(SignIn sighInModel)
    {
        try
        {

            Admin obj = new Admin();
            DbCommand cmd = _sqlDatabase.GetStoredProcCommand("PR_User_Login");
            _sqlDatabase.AddInParameter(cmd, "@UserEmail", SqlDbType.VarChar, sighInModel.Email);
            _sqlDatabase.AddInParameter(cmd, "@UserPassword", SqlDbType.VarChar, sighInModel.Password);
            IDataReader idr = _sqlDatabase.ExecuteReader(cmd);
            while (idr.Read())
            {
                obj.UserID = Convert.ToInt32(idr["UserID"]);
                obj.UserEmail = idr["UserEmail"].ToString();
                obj.UserPassword = idr["UserPassword"].ToString();
                obj.IsAdmin = Convert.ToBoolean(idr["IsAdmin"].ToString());
            }

            return obj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertUser(string UserName, string UserEmail, string UserPassword, DateTime? CreatedAt,
        DateTime? ModifiedAt)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(ConnStr);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("InsertUser");
            sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDB.ExecuteReader(dbCMD))
            {
                dataTable.Load(dataReader);
            }
            if (dataTable.Rows.Count > 0)
            {
                return false;
            }else
            {
                DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("InsertUser");
                sqlDB.AddInParameter(dbCMD1, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD1, "UserEmail", SqlDbType.VarChar,UserEmail); 
                sqlDB.AddInParameter(dbCMD1, "UserPassword", SqlDbType.VarChar, UserPassword);
                sqlDB.AddInParameter(dbCMD1, "CreatedAt", SqlDbType.DateTime, DBNull.Value);
                sqlDB.AddInParameter(dbCMD1, "ModifiedAt", SqlDbType.DateTime, DBNull.Value);
                if (Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCMD1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
            
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public bool InsertUser(SignUp userName)
    {
        throw new NotImplementedException();
    }
    }
}