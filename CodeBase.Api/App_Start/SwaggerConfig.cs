using System.Web.Http;
using WebActivatorEx;
using CodeBase.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CodeBase.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            httpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "CodeBase.Api");
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocExpansion(DocExpansion.List);
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}
