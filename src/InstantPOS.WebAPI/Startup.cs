using FluentValidation.AspNetCore;
using InstantPOS.Application;
using InstantPOS.Infrastructure;
using InstantPOS.WebAPI.Extensions;
using InstantPOS.WebAPI.Filters;
using InstantPOS.WebAPI.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using SqlKata.Execution;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Data.SqlClient;

namespace InstantPOS.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register services in Installers folder
            services.AddServicesInAssembly(Configuration);

            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddControllers(options =>
                options.Filters.Add(new ApiExceptionFilter()));

            // Add authorization services
            RegisterAuthorization(services, Configuration);

            services.AddControllers()
                .AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Instant POS API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    Description = "Enter 'Bearer' following by space and JWT.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                });

                c.AddFluentValidationRules();
                c.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();
                //c.OperationFilter<SwaggerParameterAttributeFilter>();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Instant POS API V1");
            });

            //Adds authenticaton middleware to the pipeline so authentication will be performed automatically on each request to host
            app.UseAuthentication();

            //Adds authorization middleware to the pipeline to make sure the Api endpoint cannot be accessed by anonymous clients
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public virtual void RegisterAuthorization(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorizationPolicies(configuration);
        }
    }
}
