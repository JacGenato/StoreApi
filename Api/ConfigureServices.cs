using Api.Services;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace Api
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            //services.AddControllersWithViews(options =>
            //    options.Filters.Add<ApiExceptionFilterAttribute>())
            //        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);


            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            //services.AddOpenApiDocument(configure =>
            //{
            //    configure.Title = "CleanArchitecture API";
            //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.ApiKey,
            //        Name = "Authorization",
            //        In = OpenApiSecurityApiKeyLocation.Header,
            //        Description = "Type into the textbox: Bearer {your JWT token}."
            //    });

            // //   configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            //});

            return services;
        }
    }
}
