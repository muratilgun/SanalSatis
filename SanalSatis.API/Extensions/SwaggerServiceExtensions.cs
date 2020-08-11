using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SanalSatis.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
             services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{Title = "SanalSatis API", Version = "v1"});
            });

            return services;
        }
        //middleware için
        public static IApplicationBuilder UseSwaggerDocumention(this IApplicationBuilder app)
        {
            //Swagger'ı eklemek için kullanıyoruz. Bu sayede sadece tarayıcı üzerinden bile API mizi test edebildiğimiz yardımcı araç
            app.UseSwagger();
            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json", "SanalSatis API v1");});

            return app;
        }
    }
}