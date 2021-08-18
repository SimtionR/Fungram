using InTouch.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            })
                .AddEntityFrameworkStores<FungramContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            

            var key = Encoding.ASCII.GetBytes(applicationSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };

                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
           return services.AddTransient<IIdentityService, IdentityService>()
                    .AddTransient<IProfileService, ProfileService>()
                    .AddTransient<ICommentService, CommentService>()
                    .AddTransient<IPostService, PostService>()
                    .AddTransient<IReactionService, ReactionService>()
                    .AddTransient<IUserService, UserService>();


        }

        public static IServiceCollection AddSwagger( this IServiceCollection  services)
        {
            return services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Fungram Api", Version = "v1" });

          });
        }
        
    }
}
