// using System.Diagnostics.Contracts;
// using FoodApp.Bal;
// using FoodApp.Dal;
// using Microsoft.AspNetCore.Mvc;
//
// namespace FoodApp.Areas.User.Controllers;
// [Area("User")]
// public class UserController : Controller
// {
//     private readonly UserBal userBal ;
//
//     public UserController()
//     {
//         userBal = new UserBal();
//     }
//
//     public ActionResult Index()
//     {
//         var users = userBal.SelectAllUsers();
//         return View(users);
//     }
//
//     
//
//     public IActionResult Details(int UserID)
//     {
//         var user = userBal.SelectUserByPK(UserID);
//         if (user == null)
//         {
//             return NotFound();
//         }
//
//         return View(user);
//     }
//     
//     public ActionResult Create()
//     {
//         return View();
//     }
//
//     // POST: Medium/Create
//     [HttpPost]
//     public ActionResult Create(Models.User user)
//     {
//         try
//         {
//             if (ModelState.IsValid)
//             {
//                 bool result = userBal.InsertUser(user);
//
//                 if (result)
//                 {
//                     return RedirectToAction("Index");
//                 }
//                 else
//                 {
//                     ModelState.AddModelError("", "Failed to insert user.");
//                 }
//             }
//
//             return View(user);
//         }
//         catch (Exception ex)
//         {
//             // Log the exception
//             return View(user);
//         }
//     }
//
//     
//     
//
// }   

using System.Data;
using FoodApp.Areas.Auth.Models;
using FoodApp.Dal;
using FoodApp.Dal.User;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[Action]")]

    public class UserController : Controller
    {
        public IActionResult UserLogin()
        {
            return RedirectToAction("Login");
        }

        public IActionResult UserRegister()
        {
            return RedirectToAction("UserRegister");
        }

        [HttpPost]
        public IActionResult Login(SignIn userModel)
        {
            if (ModelState.IsValid)
            {
                UserDal userDal = new UserDal();
                DataTable dt = userDal.User_LoginWith_Email_Password(userModel.Email , userModel.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach ( DataRow dr in dt.Rows)
                    {
                        Console.WriteLine(dr);
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID",dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserEmail",dr["UserEmail"].ToString());
                        HttpContext.Session.SetString("UserPassword",dr["UserPassword"].ToString());
                        break;
                    }

                    if (HttpContext.Session.GetString("UserName") != null &&
                        HttpContext.Session.GetString("UserPassword") != null &&
                        HttpContext.Session.GetString("UserName") == "Admin")
                    {
                        return RedirectToAction("Index", "Auth", new { area="Auth"});
                    }
                    else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("UserPassword")!=null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View("_Layout", userModel);

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin");
        }

        // public IActionResult Register(Models.UserModel userModel)
        // {
        //     User_Dal userDal = new User_Dal();
        //     bool IsSuccess = userDal.InsertUser(userModel.UserName, userModel.UserEmail, userModel.UserPassword,userModel.CreatedAt,userModel.ModifiedAt);
        //     if (IsSuccess)
        //     {
        //         return RedirectToAction("UserLogin");
        //     }
        //     else
        //     {
        //         return RedirectToAction("UserRegister");
        //     }
        // }
    }
}

