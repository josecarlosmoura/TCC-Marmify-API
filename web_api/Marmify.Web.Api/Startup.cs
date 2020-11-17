using AutoMapper;
using CrossCutting.DependencyInjection.DependencyInjection;
using Marmify.Application.Interfaces.Entities;
using Marmify.Domain.Entities;
using Marmify.Infraestructure.Data.Context.Context;
using Marmify.Web.Api.Authentication;
using Marmify.Web.Api.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;

namespace Marmify.Web.Api
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
            services.AddMvc(options => {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("text/json"));
            }).AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuration Context
            services.AddDbContext<MarmifyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BaseIdentity")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Version API
            services.AddApiVersioning();

            // Configuration Auto Mapper
            ConfigureAutoMapper(services);

            // Configuration Identity
            ConfigureIdentity(services);

            // Configuration JWT
            ConfigureJWT(services);

            //Configuration Swagger
            ConfigureSwagger(services);

            // Mapping Injections
            new InjectRepositories(services);
            new InjectServices(services);
            new InjectAppServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<User> userManager,
            RoleManager<ApplicationRole> roleManager, IAddressAppService addressAppService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            new IdentityInitializer(userManager, roleManager, addressAppService).Initialize();

            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marmify_Web_Api V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        #region Private Metods

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<MarmifyContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<User, ApplicationRole, MarmifyContext, long>>()
                .AddRoleStore<RoleStore<ApplicationRole, MarmifyContext, long>>();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Swagger Marmify",
                    Description = "Documentation of Marmify Web Api",
                    TermsOfService = "None"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authentication with JWT",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);
            });
        }

        private void ConfigureJWT(IServiceCollection services)
        {
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var paramsValidation = x.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudiences = tokenConfigurations.Audience;
                paramsValidation.ValidIssuers = tokenConfigurations.Issuer;

                paramsValidation.ValidateIssuerSigningKey = true;

                paramsValidation.ValidateLifetime = true;

                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        #endregion
    }
}
