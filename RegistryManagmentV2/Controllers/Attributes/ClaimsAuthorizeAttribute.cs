using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Controllers.Attributes
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        public AccountStatus AccountStatus { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            var accoutStatusClaim = claimsIdentity.FindFirst("accountStatus");
            
            if (accoutStatusClaim == null)
                return false;

            var accountStatus = accoutStatusClaim.Value;

            if (!AccountStatus.ToString().Equals(accountStatus))
            {
                return false;
            }
            
            return base.AuthorizeCore(httpContext);
        }
    }
}