using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace UI
{
    public class Startup
    {
        readonly string AllowOrigin = "AllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //    .AddJsonOptions(options =>
            //{
            //    // Use the default property (Pascal) casing
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

            //    // Configure a custom converter
            //    options.SerializerOptions.Converters.Add(new MyCustomJsonConverter());
            //});
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOrigin,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200", "http://localhost:4200", "https://bakrelsayed.github.io").
                        AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        
           
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0)
                // Add Json Options is to Make Attribute Names in Json exact as in Attributes of a class without making it small letter
                .AddJsonOptions(options => {
                    var Resolver = options.JsonSerializerOptions;
                    if (Resolver != null)
                    {
                        Resolver.PropertyNamingPolicy = null;
                        //(Resolver as DefaultContractResolver).NamingStrategy = null;
                    }
                });


            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IRepository<AppDbContext>, Repository<AppDbContext>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();
               app.UseCors();
            //app.UseCors(AllowOrigin);
            //app.UseCors(options =>
            //options.WithOrigins("https://localhost:4200")
            //.AllowAnyMethod()
            //.AllowAnyHeader()
            //.AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }



            }) ;
            app.UseDefaultFiles();
            app.UseStaticFiles();



        }
    }
}
