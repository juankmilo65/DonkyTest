using DonkeyFilesBL.Files;
using DonkeyFilesBL.Interfaces;
using DonkeyFilesDAL.Context;
using DonkeyFilesDAL.Interface;
using DonkeyFilesDAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DonkeyPhothosAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DonkeyFilesAPI", Version = "v1" });
            });
            services.AddDbContext<FilesContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DevConnection"), b => b.MigrationsAssembly("DonkeyFilesAPI")));

            services.AddScoped<FilesDetailsBll>();
            services.AddScoped<FileDetailsRepository>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
             options.WithOrigins("http://localhost:49364")
             .AllowAnyMethod()
             .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DonkeyFilesAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
