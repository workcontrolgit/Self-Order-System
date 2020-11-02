using IdentityModel;
using InstantPOS.Infrastructure.Constants;
using InstantPOS.Infrastructure.OidcConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantPOS.Infrastructure.Helpers
{
    public static class StartupHelpers
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            var adminApiConfiguration = configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                    policy =>
                        policy.RequireAssertion(context => context.User.HasClaim(c =>
                                (c.Type == JwtClaimTypes.Role && c.Value == adminApiConfiguration.AdministrationRole) ||
                                (c.Type == $"client_{JwtClaimTypes.Role}" && c.Value == adminApiConfiguration.AdministrationRole)
                            )
                        ));
            });
        }
    }
}
