using Gestao_Composicoes_Autorais_Src.Configuration;
using Gestao_Composicoes_Autorais_Src.Data;
using Gestao_Composicoes_Autorais_Src.Data.Context;
using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Service.ControllerService;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Gestao_Composicoes_Autorais_Src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddParametrosCORSCustomizados();
            services.AddControllers(options => options.Filters.Add(typeof(HttpGlobalExceptionFilter)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestão Composições Autorais - API - v0.1.0", Version = "v0.1.0" });
            });

            //TODO - Criar Container de Injeção de Dependência para Interfaces de Repositórios e Serviços de Domínio da Aplicação.
            services.AddDbContext<ApplicationContext>();
            services.AddTransient<IMusicasRepository, MusicasRepositoryExtendido>();
            services.AddTransient<IAutoresRepository, AutoresRepository>();

            services.AddTransient<IExceptionStrategyContextHandler, ExceptionStrategyContextHandler>();
            services.AddTransient(typeof(AutorConverter));
            services.AddTransient(typeof(MusicaConverter));

            services.AddTransient<IAutorService, AutorControllerServiceExtendido>();
            services.AddTransient<IMusicaService, MusicaControllerServiceExtendido>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestao Composições Autorais - API - v0.1.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseParametrosCorsCustomizados();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
