using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleNLayerProject.API.DTOs;
using SampleNLayerProject.API.Filters;
using SampleNLayerProject.Core.Repositories;
using SampleNLayerProject.Core.Services;
using SampleNLayerProject.Core.UnitOfWorks;
using SampleNLayerProject.Data;
using SampleNLayerProject.Data.Repositories;
using SampleNLayerProject.Data.UnitOfWorks;
using SampleNLayerProject.Service.Services;
using SampleNLayerProject.API.Extensions;

namespace SampleNLayerProject.API
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
            services.AddDbContext<AppDbContext>(options =>
            {
                // we need to use second parameter to tell api project, our data layer is in other class library.
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => {
                    o.MigrationsAssembly("SampleNLayerProject.Data");

                });
            });

            // Dependency Injection

            // when a request comes up and it sees IUnitOfWork in somewhere of the project (constructors of the classes),
            // it'll create a new instance of UnitOfWork and will use it instead of IUnitOfWork.
            // If in one request there is more than one IUnitOfWork, it will use same instance for those also.
            // If we want to create new instance for every new IUnitOfWork, we need to use AddTransient instead of AddScoped.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // we registered NotFoundFilter as ServiceFilter. We have to register it if the filter class has to take a parameter.
            services.AddScoped(typeof(NotFoundFilter<>));

            // we use typeof and <> here because we need to explain these classes are generic.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            // for configuring AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(o => {
                // we are able to add filters to all controllers and their endpoints.
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // that means, we disabled default json data for model state invalid errors.
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

            // instead of writing whole logic here, we created a new extension method and used it here above.
            //app.UseExceptionHandler(config =>
            //{
            //    config.Run(async context =>
            //    {
            //        context.Response.StatusCode = 500;
            //        context.Response.ContentType = "application/json";
            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if(error != null)
            //        {
            //            var exception = error.Error;
            //            ErrorDto errorDto = new ErrorDto();
            //            errorDto.Status = 500;
            //            errorDto.Errors.Add(exception.Message);

            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
            //        }
            //    });
            //});

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
