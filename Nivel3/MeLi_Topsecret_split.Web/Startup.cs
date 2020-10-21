using System.Reflection;
using MediatR;
using MeLi_Topsecret_split.Domain;
using MeLi_Topsecret_split.Domain.CommandModel;
using MeLi_Topsecret_split.Domain.Repository;
using MeLi_Topsecret_split.Persistence;
using MeLi_Topsecret_split.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchipService.Persistence.Sql;

namespace MeLi_Topsecret_split.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(IUnitOfWork));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
