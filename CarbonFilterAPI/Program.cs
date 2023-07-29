using Microsoft.EntityFrameworkCore;
using CarbonFilter.Models;
using Microsoft.AspNetCore.Identity;
using static OpenIddict.Abstractions.OpenIddictConstants;
using CarbonFilterAPI.Services;
using OpenIddict.Server.AspNetCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace CarbonFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DevConnection") ?? 
                throw new InvalidOperationException("Connection string 'DevConnection' not found.");

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarbonFilter WebAPI", Version = "v1" });
                c.AddSecurityDefinition(
                    "oauth",
                    new OpenApiSecurityScheme
                    {
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            {
                                //AuthorizationUrl = new Uri("/connect/token", UriKind.Relative),
                                TokenUrl = new Uri("/connect/token", UriKind.Relative)
                            }
                        },
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization,
                        Type = SecuritySchemeType.OAuth2
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                                { Type = ReferenceType.SecurityScheme, Id = "oauth" },
                        },
                        new[] { "api" }
                    }
                    }
                );
            }
            );

            builder.Services.AddDbContext<SurveyDbContext>(options =>
            {
                // Configure Entity Framework Core to use Microsoft SQL Server.                
                options.UseSqlServer(connectionString);

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = Claims.Role;
            });

            builder.Services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<SurveyDbContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options.SetTokenEndpointUris("/connect/token");

                    // Enable the client credentials flow.
                    options.AllowClientCredentialsFlow()
                           .AllowPasswordFlow()
                           .SetAccessTokenLifetime(TimeSpan.FromHours(12));

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    options.SetIssuer(new Uri("https://localhost/CarbonFilterAuthentication"));

                    // Register the ASP.NET Core host and configure the ASP.NET Core options.
                    options.UseAspNetCore()
                        .EnableTokenEndpointPassthrough()
                        .EnableAuthorizationEndpointPassthrough()
                        .EnableUserinfoEndpointPassthrough()
                        .DisableTransportSecurityRequirement();
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    //options.AddAudiences("react-client");
                    //options.AddAudiences("Swagger");

                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

            // Register the worker responsible of seeding the database with the sample clients.
            // Note: in a real world application, this step should be part of a setup script.
            builder.Services.AddHostedService<AllClientWorkers>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "CarbonFilter WebAPI v1");
                    c.OAuthClientId("Swagger");
                    c.OAuthClientSecret("Swagger-Secret");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors(builder =>
            //{
            //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });

            app.Run();
        }
    }
}