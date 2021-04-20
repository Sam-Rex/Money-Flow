using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Api.Domain.Repositories;
using Api.Domain.Services;
using Api.Persistance.Contexts;
using Api.Persistance.Repositories;
using Api.Models.Services;
using Api.Models.Services.Account;
using AutoMapper;
using Api.Domain.Models.Account;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Api.Domain.Services.Account;
using Api.Domain.Services.Logging;
using NLog;
using Api.Extensions;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddControllers().AddNewtonsoftJson(options=>{
                options.SerializerSettings.ContractResolver=new DefaultContractResolver();
            });
            

            //services.AddDbContext<AppDbContext>(options=>{options.UseInMemoryDatabase("SupermarketDb");
            //});
            
            // Resgister CategotyTypeRepositories for dependancy injection
            services.AddScoped<ICategoryTypeRepository,CategoryTypeRepository>();
            // Resgister CategoryType Services for dependancy injection
            services.AddScoped<ICategoryTypeService,CategoryTypeService>();
            // Resgister categoriesRepositories for dependancy injection
            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            // Resgister categories Service for dependancy injection
            services.AddScoped<ICategoriesService,CategoriesService>();

            // Resgister MoneyRepositories for dependancy injection
            services.AddScoped<IMoneyFlowRebository, MoneyFlowRepository>();
            // Resgister Money Flow Service for dependancy injection
            services.AddScoped<IMoneyFlowService, MoneyFlowService>();


            // Resgister Account Service for dependancy injection
            services.AddScoped<IAccountServices, AccountServices>();
            // Resgister ILoggerManager Service for dependancy injection
            services.AddScoped<ILoggerManager, LoggerManager>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

         
            //===================== Confugure SQL Server ====================================
            services.AddDbContextPool<OS_Plus_Money_Flow>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

            //===================== Confugure Identity ====================================
            
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.";
                options.User.RequireUniqueEmail = false;

            });

            services.AddIdentity<User, IdentityRole>()
   .AddEntityFrameworkStores<OS_Plus_Money_Flow>();

            //===================== Confugure JWT ====================================

            var JWTSetting = Configuration.GetSection("JWTConfiguration");
            

             services.AddAuthentication(opt =>
              {
                  opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = JWTSetting.GetSection("ValidIssuer").Value,
                        ValidAudience = JWTSetting.GetSection("ValidAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSetting.GetSection("Secret").Value))
                    };
                });

            //===================== Confugure File Upload====================================

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerManager logger)
        {
            /*
            using(var serviceScope=app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()){
                var context=serviceScope.ServiceProvider.GetRequiredService<OS_Plus_Money_Flow>();
                context.Database.EnsureCreated();
            }
            */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger);


            // Files
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            //app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources/uploads")),
                RequestPath = new PathString("/Resources/Uploads")
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
