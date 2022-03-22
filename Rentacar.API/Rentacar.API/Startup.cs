using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rentacar.DataAccess;
using Rentacar.DataAccess.Interfaces;
using Rentacar.DataAccess.Repositories;
using Rentacar.Services.Interfaces;
using Rentacar.Services.Services;

namespace Rentacar.API
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<RentacarContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RentacarConnection")));

            services.AddSwaggerGen();

            services.AddControllers();

            // Services
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFilterService, FilterService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IPaymentProcessingService, StripeIntegrationService>();

            // Repositories
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFilterRepository, FilterRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (IServiceScope scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<RentacarContext>().Database.Migrate();
            }

            //app.UseExceptionHandler("/error");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
