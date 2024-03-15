using FoodApp.Areas.User.Models;

namespace FoodApp.Dal.User;

public class User_Dal : User_DalBase
{
    public bool InsertUser(string authModelUserName, string authModelUserEmail, string authModelUserPassword, DateTime authModelCreatedAt, DateTime authModelModifiedAt)
    {
        throw new NotImplementedException();
    }
}

