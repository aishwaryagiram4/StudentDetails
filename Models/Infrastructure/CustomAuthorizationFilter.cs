using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.Models.Infrastructure
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        //to confirm request is autorized or not
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("EmailId") == null)
            {
                context.Result = new RedirectResult("~/Home/InvalidSession");
            }
        }

    }
}
