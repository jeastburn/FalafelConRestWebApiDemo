using System;
using System.Security.Principal;

namespace RestWebApi.Classes
{
    public class ApiIdentity : IIdentity
    {

        public ApiIdentity(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");

            this.Name = username;
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}