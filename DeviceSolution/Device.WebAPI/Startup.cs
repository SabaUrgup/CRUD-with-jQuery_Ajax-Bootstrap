using Device.Business.Abstract;
using Device.Business.Concrete;
using Device.DataAccessLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Device.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device.WebAPI", Version = "v1" });
            });

            services.AddDbContext<DeviceDatabaseContext>();
            // her nesne için bir defa oluþturulur --> AddDbContext

            services.AddScoped<ITvService, TvService>();
            services.AddScoped<ITelService, TelService>();
            // Ýstek geldikçe nesne oluþturur --> AddScoped

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    // Servisi belirli bir adresten gelen taleplere ama
                    //builder.WithOrigins("http://localhost:3000","http://94.73.164.170:")
                    // Servisi tm taleplere ama
                     builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device.WebAPI v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
