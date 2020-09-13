using Autofac;
using Autofac.Integration.WebApi;
using CodeBase.Api.App_Start;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CodeBase.Api
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.SuppressDefaultHostAuthentication();
            httpConfiguration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            httpConfiguration.Formatters
                  .JsonFormatter
                  .MediaTypeMappings
                  .Add(new RequestHeaderMapping("Accept", "text/html",
                  StringComparison.InvariantCultureIgnoreCase, true, "application/json"));

            httpConfiguration.Formatters
                  .JsonFormatter
                  .SerializerSettings
                  .ContractResolver = new CamelCasePropertyNamesContractResolver();

            httpConfiguration.Formatters
                  .JsonFormatter
                  .SerializerSettings
                  .NullValueHandling = NullValueHandling.Ignore;

            httpConfiguration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacWebApiConfig.Register(new ContainerBuilder()));

            SwaggerConfig.Register(httpConfiguration);

            return httpConfiguration;
        }
    }
}
