using CurrencyConverter.BLL;
using CurrencyConverter.BLL.Interfaces;
using CurrencyConverter.Utilities;
using CurrencyConverter.Utilities.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

namespace CurrencyConverter
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.Configure<UserSettings>(Configuration.GetSection("UserSettings"));

            ConfigureTransientServices(services);
            ConfigureSingletonServices(services);

            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });

        }

        private static void ConfigureTransientServices(IServiceCollection services)
        {

            services.AddTransient<ICurrency, Currency>();
        }
        private static void ConfigureSingletonServices(IServiceCollection services)
        {

            services.AddSingleton<IUserSettings, UserSettings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ApiCorsPolicy");
            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
        }
    }
}
