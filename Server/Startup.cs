using InTouch.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Extensions;
using System.Text;

namespace Server
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
            var appSettingsConfiguration = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettingsConfiguration);
            var applicationSettings = appSettingsConfiguration.Get<ApplicationSettings>();

            services.AddControllers();

            services.AddApplicationServices()
                .AddSwagger();
        
      

            services.AddDbContext<FungramContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("FungramDB"));
            })
            .AddIdentity()
            .AddJwtAuthentication(applicationSettings);

            //services.AddIdentity();


           /* services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            })
                .AddEntityFrameworkStores<FungramContext>();
*/
           // services.AddJwtAuthentication()

         /*   var appSettingsConfiguration = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettingsConfiguration);

            var applicationSettings = appSettingsConfiguration.Get<ApplicationSettings>();
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

                });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(options =>
               { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Fungram Api");
                   options.RoutePrefix = string.Empty;
               
                   });
            app.UseRouting();

            app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseAuthentication();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    
            });
        }
    }
}
