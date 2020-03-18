using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using EventPlanning.Domain.Interfaces;

namespace EventPlanningWebApi.Attributes
{
    public class CustomAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var userService = (IUsersService) context.Request.GetDependencyScope().GetService(typeof(IUsersService));
            context.Principal = null;
            AuthenticationHeaderValue authentication = context.Request.Headers.Authorization;
            if (authentication != null && authentication.Scheme == "Basic")
            {
                string[] authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
                var user = await userService.GetUser(authData[0], authData[1]);
                string[] roles = new string[] { user.Role };
                string login = user.Email;
                context.Principal = new GenericPrincipal(new GenericIdentity(login), roles );
            }
            if (context.Principal == null)
            {

                //context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[] {
                //    new AuthenticationHeaderValue("Basic") }, context.Request);
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}