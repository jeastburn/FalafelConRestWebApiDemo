using System.Web.Http;
using System.Web;

namespace RestWebApi.Classes
{
    [BasicAuthentication]
    public class AuthorizedApiController : ApiController
    {
        public ApiIdentity AuthorizedUser { get { return ((ApiIdentity)HttpContext.Current.User.Identity); } }
    }
}