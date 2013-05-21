using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using System.Security.Principal;
    using System.Text;
    using System.Web.Http;

namespace RestWebApi.Classes
{

    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string username = decodedToken.Substring(0, decodedToken.IndexOf(":", StringComparison.Ordinal));
                string password = decodedToken.Substring(decodedToken.IndexOf(":", StringComparison.Ordinal) + 1);

                // Validate Username and Password
                if (username == "restuser" && password == "password")
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(username), new string[] { });

                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }

}