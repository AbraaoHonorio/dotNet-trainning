using Elmah.Io.AspNetCore;
using Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using TesteStore.Domain.StoreContext.Handlers;
using TesteStore.Domain.StoreContext.Repositories;
using TesteStore.Domain.StoreContext.Services;
using TesteStore.Infra.Providers;
using TesteStore.Infra.StoreContexts.DataContexts;
using TesteStore.Infra.StoreContexts.Repositories;
using TesteStore.Shared;
namespace TesteStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            // configurando o MVC e removendo valores nulos do retorno 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opcoes =>
                {
                    opcoes.SerializerSettings.NullValueHandling =
                    Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // NativeInjector - IoC
            services.AddScoped<TesteDataContext, TesteDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            // Configura o modo de compressão
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            // Documentação
            services.AddSwaggerGen(options =>
           {
               options.SwaggerDoc("v1", info: new Info { Title = "Teste Store", Version = "V1" });
               options.SwaggerDoc("v2", info: new Info { Title = "Teste Store", Version = "V1" });
           });

            // Log
            services.AddElmahIo(o =>
            {
                o.ApiKey = "7d70961af4ce45c188880609bab341ec";
                o.LogId = new Guid("2a59e917-7bca-4ec7-ab73-d8202f589e51");
            });

            // Configurando o banco
            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " Api Teste Store - V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Api Teste Store - V2");

            });

            app.UseElmahIo();
        }
    }
}
