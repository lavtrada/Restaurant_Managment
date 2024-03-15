using FoodApp.Areas.Auth.Models;
using FoodApp.Areas.User.Models;
using FoodApp.Dal;
using FoodApp.Models;

namespace FoodApp.Bal;

public class LoginBal
{
    
    private static LoginDal _loginDal;

    public LoginBal()
    {
        _loginDal = new LoginDal();
    }

    public Admin PR_User_Login(SignIn sighInModel)
    {
        try
        {
            return _loginDal.PR_User_Login(sighInModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertUser(SignUp signUp)
    {
        try
        {
            return _loginDal.InsertUser(signUp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}