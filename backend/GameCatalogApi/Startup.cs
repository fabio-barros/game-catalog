using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCatalogApi.Services;
using GameDataApp.Mongo;
using GameDataApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using UserDataApp.Database;
using UserDataApp.Services.GameServices;
using UserDataApp.Services.LoginServices;
using UserDataApp.Services.UserServices;

namespace GameCatalogApi
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
            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("corsPolicy", options => options.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader().WithExposedHeaders(HeaderNames.ContentRange));

            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameCatalogApi", Version = "v1" });
            });

            //MONGO GAMES DB
            services.Configure<GameCatalogDbConfig>(Configuration);
            services.AddSingleton<IDbClient, DbClient>();
            services.AddTransient<IGameServices, GameServices>();

            //POSTGRES USERS DB
            services.AddDbContext<UserAppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("NpgConnectionString")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameInfoService, GameInfoService>();
            services.AddScoped<ILoginService, LoginService>();

            //JWT 
            var secret =
                Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfig:Secret").Value);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secret),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddSingleton<ITokenService, TokenService>();


            //JSON SERIALIZER
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameCatalogApi v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("corsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
