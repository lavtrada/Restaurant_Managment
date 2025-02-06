using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using FoodApp.Areas.Auth.Models;
using FoodApp.Areas.User.Models;
using FoodApp.Dal;
using FoodApp.Dal.User;

namespace FoodApp.Bal;
//
public class UserBal
{
    private UserDal userDal;

    public UserBal()
    {
        userDal = new UserDal();
    }

    #region Insert User

    public bool InsertUser(SignUp signUp)
    {
        try
        {
            return userDal.InsertUser(signUp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    //     private readonly User_Dal userDAL;
//
//     public UserBal()
//     {
//         userDAL =  new User_Dal();
//     }
//
//     #region PR_User_SelectAll
//     public List<UserModel> SelectAllUsers()
//     {
//         try
//         {
//             var user = User_Dal.SelectAllUsers();
//             return user;
//         }
//         catch
//         {
//             return null;
//         } 
//     }
//     #endregion
//
//     // #region Create user
//     //
//     // public void InsertUsers(Users user)
//     // {
//     //     if (user == null) 
//     //         throw new ArgumentNullException(nameof(user), "User object cannot be null");
//     //     userDAL.InsertUser(user);
//     // }
//     //
//     // #endregion
//
//     #region Select by PK
//
//     public UserModel SelectUserByPK(int UserID)
//     {
//         try
//         {
//             UserModel userModel = userDAL.SelectUserByPK(UserID);
//             return userModel;
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//             throw;
//         }
//     }
//
//
//     #endregion
//     
//     // #region InsertUser
//
//     public bool InsertUser(UserModel userModel)
//     {
//         try
//         {
//             return userDAL.InsertUser(userModel);
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e);
//             throw;
//         }

//
//     #endregion
//
//     
//     
}