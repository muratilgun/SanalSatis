using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanalSatis.API.Extensions;
using SanalSatis.API.Helpers;
using SanalSatis.API.Middleware;
using SanalSatis.Infrastructure.DataAccess;

namespace SanalSatis.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<ProjectContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            services.AddApplicationServices();
            services.AddSwaggerDocumentation();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //önemli
            app.UseMiddleware<ExceptionMiddleware>();
            //hata işleyici middleware
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            //statik dosyaları apiye gönderiyoruz resim vs..
            app.UseStaticFiles();

            app.UseAuthorization();
            
            app.UseSwaggerDocumention();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
