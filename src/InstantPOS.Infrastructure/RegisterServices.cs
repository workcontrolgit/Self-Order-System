﻿
using Microsoft.Extensions.DependencyInjection;
using InstantPOS.Infrastructure.DatabaseServices;
using Microsoft.Extensions.Configuration;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Common;
using SqlKata.Execution;
using SqlKata.Compilers;
using System.Data.SqlClient;
using System;
using InstantPOS.Application.MockDataServices.Interfaces;
using InstantPOS.Infrastructure.MockDataServices;
using InstantPOS.Infrastructure.Helpers;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;

namespace InstantPOS.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            services.AddTransient<IProductDataService, ProductDataServices>();
            services.AddTransient<IContactDataService, ContactDataServices>();
            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new SqlConnectionFactory(configuration[Configuration.ConnectionString]);
            });


            //ID4 Token Validation
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = configuration["Sts:ServerUrl"];
                        options.RequireHttpsMetadata = false;
                        options.ApiName = configuration["ApiResource:ApiName"];
                    });

            //ID4 Authorize Filter Policy
            services.AddAuthorizationPolicies(configuration);

            //SQLKata DI Container https://sqlkata.com/docs/
            services.AddScoped(factory =>
            {
                return new QueryFactory
                {
                    Compiler = new SqlServerCompiler(),
                    Connection = new SqlConnection(configuration[Configuration.ConnectionString]),
                    Logger = compiled => Console.WriteLine(compiled)
                };
            });
            //GenFu DI Container https://github.com/MisterJames/GenFu
            services.AddSingleton(typeof(IMockDataService<>), typeof(MockDataServices<>));
            return services;
        }
    }
}
