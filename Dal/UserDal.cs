using System.Data;
using System.Data.Common;
using FoodApp.Areas.Auth.Models;
using FoodApp.Areas.User.Models;
using FoodApp.Bal;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace FoodApp.Dal.User;

public class UserDal : DAL_Helper
{
    
    private static SqlDatabase _sqlDatabase;
    private string _connectionString;
    
    public UserDal()
    {
        _sqlDatabase = new SqlDatabase(ConnStr);
    }
    
    #region InsertUser
    
    public bool InsertUser(SignUp signUp)
    {
        DbCommand dbCommand = _sqlDatabase.GetStoredProcCommand("InsertUser");
        _sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, signUp.UserName);
        _sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, signUp.Email);
        _sqlDatabase.AddInParameter(dbCommand, "@UserPassword", SqlDbType.VarChar, signUp.Password);
        _sqlDatabase.AddInParameter(dbCommand,"IsAdmin",SqlDbType.Bit,signUp.IsAdmin);
        return Convert.ToBoolean(_sqlDatabase.ExecuteNonQuery(dbCommand));
    }

    #endregion
    public DataTable User_LoginWith_Email_Password(string userModelEmail, string userModelPassword)
    {
        throw new NotImplementedException();
    }
}