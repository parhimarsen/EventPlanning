using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.Cors;
using EventPlanningWebApi.Attributes;
using FluentValidation.WebApi;

namespace EventPlanningWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Filters.Add(new CustomAuthenticationAttribute());
            config.Filters.Add(new ModelValidationFilterAttribute());
            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.EnableCors(new EnableCorsAttribute("http://localhost:3000", "*", "*"));


        }
    }
}
