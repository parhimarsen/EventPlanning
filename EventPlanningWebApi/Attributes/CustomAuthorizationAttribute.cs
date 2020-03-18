using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EventPlanning.Domain.Interfaces;
using EventPlanning.Domain.Models;

namespace EventPlanningWebApi.Attributes
{
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private string[] rolesList;
        public CustomAuthorizationAttribute(params string[] roles)
        {
            this.rolesList = roles;
        }
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            IPrincipal principal = actionContext.RequestContext.Principal;

            for (int i = 0; i < rolesList.Length; i++)
            {
                if (principal == null || !principal.IsInRole(rolesList[i]))
                {
                    return Task.FromResult<HttpResponseMessage>(
                        actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
                }
                else
                {
                    return continuation();
                }
            }

            return continuation();
        }

        public bool AllowMultiple { get { return false; } }
    }
}