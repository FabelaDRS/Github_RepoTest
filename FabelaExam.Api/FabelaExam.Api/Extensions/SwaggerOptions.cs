using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FabelaExam.Api.Extensions
{
    public class SwaggerOptions: IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var item in _provider.ApiVersionDescriptions) {
                options.SwaggerDoc(
                    item.GroupName,
                    CreateVersionInformation(item));
            }
        }

        private OpenApiInfo CreateVersionInformation(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Exam Api",
                Version = description.ApiVersion.ToString()
            };
            if (description.IsDeprecated)
            {
                info.Description += "";
            }
            return info;
        }
    }
}
