using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gestao_Composicoes_Autorais_Src.Configuration
{
    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddParametrosCORSCustomizados(this IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("AllowAll", builder => _ = builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            ));

            return services;
        }

        public static IApplicationBuilder UseParametrosCorsCustomizados(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors("AllowAll");

            return applicationBuilder;
        } 
    }
}
