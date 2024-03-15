// using FoodApp.Areas.User.Models;
// using FoodApp.Bal;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
//
// namespace FoodApp.Models;
//
// public class CheckAdminAccess :ActionFilterAttribute,IAuthorizationFilter
// {
//     public void OnAuthorization(AuthorizationFilterContext context)
//     {
//         var rd = filterContext.RouteData;
//         string currentAction = rd.Values["action"].ToString();
//         string currentController = rd.Values["controller"].ToString();
//
//         if (filterContext.HttpContext.Session.GetString("UserId") == null)
//         {
//
//             filterContext.Result = new RedirectToActionResult("Login", "Auth", new { Area = "Auth" });
//         }
//         else
//         {
//             string userId = filterContext.HttpContext.Session.GetString("UserId");
//             int userID = int.Parse(userId);
//
//             // UserBal _userbalbase = new UserBal();
//             User User = _userbalbase.SelectUserByPK(userID);
//
//             if (User.IsAdmin != true)
//             {
//                 filterContext.Result = new RedirectToActionResult("Login", "Auth", new { Area = "Auth" });
//             }
//         }
//     }
// }