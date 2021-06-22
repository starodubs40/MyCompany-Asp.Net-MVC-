using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;
using MyCompany.Service;

namespace MyCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //ïîäêëþ÷àåì êîíôèã èç appsetting.json
            Configuration.Bind("Project", new Config());

            //ïîäêëþ÷àåì íóæíûé ôóíêöèîíàë ïðèëîæåíèÿ â êà÷åñòâå ñåðâèñîâ
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //ïîäêëþ÷àåì êîíòåêñò ÁÄ
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //íàñòðàèâàåì identity ñèñòåìó
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //íàñòðàèâàåì authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });


            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "clientId";
                    options.ClientSecret = "clientSecret";
                })
                .AddFacebook(options =>
                {
                    options.ClientId = "clientId";
                    options.ClientSecret = "clientSecret";
                });
                
                

            //íàñòðàèâàåì ïîëèòèêó àâòîðèçàöèè äëÿ Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //íàñòðàèâàåì ïîëèòèêó àâòîðèçàöèè äëÿ Manager area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("ManagerArea", policy => { policy.RequireRole("manager"); });
            });

            //äîáàâëÿåì ñåðâèñû äëÿ êîíòðîëëåðîâ è ïðåäñòàâëåíèé (MVC)
            services.AddControllersWithViews(x =>
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                })
                //âûñòàâëÿåì ñîâìåñòèìîñòü ñ asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            //äîáàâëÿåì ñåðâèñû äëÿ êîíòðîëëåðîâ è ïðåäñòàâëåíèé(MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Manager", "ManagerArea"));
            })
                //âûñòàâëÿåì ñîâìåñòèìîñòü ñ asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!! ïîðÿäîê ðåãèñòðàöèè middleware î÷åíü âàæåí

            //â ïðîöåññå ðàçðàáîòêè íàì âàæíî âèäåòü êàêèå èìåííî îøèáêè
            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage();

            //ïîäêëþ÷àåì ïîääåðæêó ñòàòè÷íûõ ôàéëîâ â ïðèëîæåíèè (css, js è ò.ä.)
            app.UseStaticFiles();

            //ïîäêëþ÷àåì ñèñòåìó ìàðøðóòèçàöèè
            app.UseRouting();

            //ïîäêëþ÷àåì àóòåíòèôèêàöèþ è àâòîðèçàöèþ
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //ðåãèñòðèóðóåì íóæíûå íàì ìàðøðóòû (åíäïîèíòû)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("manager", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
