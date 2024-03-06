// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Brokers.Apis;
using Jaunts.Portal.Web.Client.Brokers.DateTimes;
using Jaunts.Portal.Web.Client.Brokers.Loggings;
using Jaunts.Portal.Web.Client.Brokers.Navigations;
using Jaunts.Portal.Web.Client.Services.Foundations.Identity;
using Jaunts.Portal.Web.Client.Services.Foundations.Rides;
using Jaunts.Portal.Web.Client.Services.Foundations.Users;
using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Jaunts.Portal.Web.Client.Services.Views.RideViews;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Jaunts.Portal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            AddRootDirectory(services);

            services.AddScoped<IApiBroker, ApiBroker>();
            services.AddScoped<ILogger, Logger<LoggingBroker>>();
            services.AddScoped<ILoggingBroker, LoggingBroker>();
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<INavigationBroker, NavigationBroker>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRideService, RideService>();
            services.AddScoped<IRideViewService, RideViewService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IIdentityViewService, IdentityViewService>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            SyncfusionLicenseProvider.RegisterLicense(
                licenseKey: "Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjW31YcHFQQ2JUV0F0WA==");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAntiforgery();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapBlazorHub();
                endpoints.MapRazorComponents<App>()
                    .AddInteractiveServerRenderMode()
                    .AddInteractiveWebAssemblyRenderMode()
                    .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
                //endpoints.MapFallbackToPage("/submit");
            });
        }

        private static void AddRootDirectory(IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                options.RootDirectory = "/Views/Pages";
            });
          
        }
    }
}
