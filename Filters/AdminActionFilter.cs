

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetProject.Namespace
{
    public class AdminActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // ActionFilterAttribute bu sınıf .NET'in filtreleme sınıfıdır türetilir(AdminActionFilter). Öncesinde ya da sonrasında yapılacak işlemlerle ilgili işlevsellik katar.
            // OnActionExecuting: Action (aksiyon) başlamadan önce yapılacak işlemleri belirler.
            // OnActionExecuted: Action tamamlandıktan sonra yapılacak işlemleri belirler.
            // context.HttpContext.Session: HTTP oturumuna (session) erişim sağlar.
            // context.ActionArguments: Action'a gönderilen parametreleri içerir.

            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();

            // LogIn
            if (context.HttpContext.Session.GetString("AdminUser") != null)
            {
                // LogIn to Home
                if (controller == "Admin" && action == "Login")
                {
                    context.Result = new RedirectToActionResult("Index", "Admin", null);
                    return;
                }
            }
            else
            {
                // LogOut to Login
                if (controller != "Admin" || action != "Login")
                {
                    context.Result = new RedirectToActionResult("Login", "Admin", null);
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}