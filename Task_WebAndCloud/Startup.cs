
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;
using Task_WebAndCloud.Data;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud
{
    public class Startup
    {

        private IConfiguration Configuration { get; }
        public TimeSpan TimeSpa { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /* services.AddDefaultIdentity<User>()
                 .AddEntityFrameworkStores<ApplicationDbContext>();*/

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                opt.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IPostsRepository, Repository>();

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
            });

            /*services.AddAntiforgery(options =>
            {
                options.FormFieldName = "AntiforgeryFieldname";
                options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
                options.SuppressXFrameOptionsHeader = false;
            });*/

            services.AddHttpContextAccessor();
        }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseHsts();
           /* app.UseHsts(new HstsOptions
            {
                Duration = TimeSpan.FromDays(365),
                IncludeSubDomains = true,
                Preload = true
            });*/

            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("pagination", "Posts/Page{postPage}", new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("userHome", "User/Page{postPage}", new { controller = "User", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

          /*  app.Use(next => context =>
            {
                string path = context.Request.Path.Value;
                var tokens = antiforgery.GetAndStoreTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                    new CookieOptions() { HttpOnly = false });
 
                return next(context);
            });*/

            SeedData.Populate(app);
            Task.Run(async () =>
            {
                await SeedDataUser.EnsurePopulated(app);
            }).Wait();
        }
    }
}
