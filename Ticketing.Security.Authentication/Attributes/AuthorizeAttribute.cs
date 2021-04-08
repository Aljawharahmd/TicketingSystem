using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;

namespace Ticketing.Security.Authentication.Attributes
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public UserType[] Rules { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var user = (TokenUser)context.HttpContext.Items["User"];
            if (!HasAccess(user))
                context.Result = new RedirectResult("~/Account/Login");
        }
        private bool HasAccess(TokenUser user)
        {
            return (user != null && (Rules != null && Rules.Length > 0 && Rules.Any(a => a == user.Type)));
        }
    }

}
