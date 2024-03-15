    using System.Data;
    using System.Data.Common;
    using FoodApp.Bal;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

    namespace FoodApp.Areas.User.Models

    {

        public class User_DalBase : DAL_Helper
        {
            #region Method: User_LoginWith_Email_Password

            public DataTable User_LoginWith_Email_Password(string UserName, string Password)
            {
                try
                {
                    SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                    DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.User_LoginWith_Email_Password");
                    sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                    sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                    DataTable dt = new DataTable();
                    using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                    {
                        dt.Load(dr);
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            #endregion
        }
    }