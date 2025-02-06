using System.Data;
using FoodApp.Areas.Auth.Models;
using FoodApp.Areas.User.Models;
using FoodApp.Bal;
using FoodApp.Dal;
using FoodApp.Dal.User;
using FoodApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Route("Auth/[controller]/[Action]")]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.SignIn authModel)
        {
            if (ModelState.IsValid)
            {
                Admin obj = new Admin();

                LoginBal _dB = new LoginBal();
                obj = _dB.PR_User_Login(authModel);

                if (obj.UserID == 0)
                {
                    TempData["Error"] = "Email Or Password Is InCorrect";
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserID", obj.UserID);
                     HttpContext.Session.SetString("UserName",obj.UserName);
                    HttpContext.Session.SetString("UserPassword",obj.UserPassword);
                    HttpContext.Session.SetString("UserEmail", obj.UserEmail);
                    HttpContext.Session.SetString("IsAdmin", obj.IsAdmin.ToString());
                }

                return RedirectToAction("Index", "Auth", new { area = "Auth" });
            }

            return View("UserLogin", authModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin");
        }

        public IActionResult Register(SignUp signUp)
        {
            UserDal userDal = new UserDal();
            bool IsSuccess = userDal.InsertUser(signUp);
            
            if (IsSuccess)
            {
                return RedirectToAction("UserLogin");
            }
            else
            {
                return RedirectToAction("UserRegister");
            }
        }
        



    }
}