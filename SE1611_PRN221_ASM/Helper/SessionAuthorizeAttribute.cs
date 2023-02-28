using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Repository;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Helper
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetObject<UserSession>("UserSession");
            if (context.Filters.Any(f => f is IAllowAnonymousFilter || f is AllowAnonymousAttribute))
            {
                return;
            }
            if (session == null)
            {
                context.Result = new RedirectToRouteResult(
                    new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            
            else if (session.RoleId == (int)RoleId.Customer)
            {
                // User is logged in as a regular user, restrict access to the admin controller and its actions
                if (context.RouteData.Values["controller"].ToString().ToLower() == "admin")
                {
                    // Redirect to an error page or some other appropriate action
                    context.Result = new RedirectToRouteResult(
                        new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
                else
                {
                    // User is allowed to access the requested controller and action
                    base.OnActionExecuting(context);
                }
            }
            else if (session.RoleId == (int)RoleId.Admin)
            {
                if (context.RouteData.Values["controller"].ToString().ToLower() != "admin")
                {
                    // Redirect to an error page or some other appropriate action
                    context.Result = new RedirectToRouteResult(
                        new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { controller = "Admin", action = "Index" }));
                }
                else
                {
                    base.OnActionExecuting(context);
                }
               
            }
            else
            {
                // User has an unknown role, redirect to an error page or some other appropriate action
                context.Result = new RedirectToRouteResult(
                    new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { controller = "Home", action = "Error" }));
            }

        }

    }
}

