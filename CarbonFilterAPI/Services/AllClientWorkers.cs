using CarbonFilter.Models;
using Microsoft.AspNetCore.DataProtection;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace CarbonFilterAPI.Services
{
    public class AllClientWorkers : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public AllClientWorkers(IServiceProvider serviceProvider) 
        => _serviceProvider = serviceProvider;
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<SurveyDbContext>();
            await context.Database.EnsureCreatedAsync();

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
            
            if (await manager.FindByClientIdAsync("react-client") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "react-client",
                    ClientSecret = "react-client-Secret",
                    DisplayName = "Carbon Filter UI",
                    Permissions =
                    {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.Password, // need username and password
                        Permissions.GrantTypes.ClientCredentials
                    }
                });
            }

            if (await manager.FindByClientIdAsync("Postman-Test") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "Postman-Test",
                    ClientSecret = "Postman-Secret",
                    DisplayName = "Postman",
                    Permissions =        
                    {
                        Permissions.Endpoints.Authorization,
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.ClientCredentials
                    }
                });
            }

            if (await manager.FindByClientIdAsync("Swagger") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "Swagger",
                    ClientSecret = "Swagger-Secret",
                    DisplayName = "SwaggerUI UI",
                    Permissions =
                    {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials
                    }
                });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
