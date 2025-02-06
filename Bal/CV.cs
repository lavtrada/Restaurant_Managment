namespace FoodApp.BAL;
    public class CV
    {
        private static IHttpContextAccessor _HttpContextAccessor;

        static CV()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetInt32("UserID"));
        }

        public static string UserName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");
        }

        public static string Email()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("UserEmail");
        }

        public static bool IsAdmin()
        {
            return Convert.ToBoolean(_HttpContextAccessor.HttpContext.Session.GetString("IsAdmin"));
        }
    }