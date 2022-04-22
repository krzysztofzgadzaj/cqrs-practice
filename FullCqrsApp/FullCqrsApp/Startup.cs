using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using FullCqrsApp.Contracts.Base.Behavior;
using FullCqrsApp.Core.Bus.CommandBus;
using FullCqrsApp.Core.Bus.QueryBus;
using FullCqrsApp.Core.Exception;
using FullCqrsApp.Persistence;
using FullCqrsApp.Persistence.Repository.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FullCqrsApp
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
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FullCqrsApp", Version = "v1"});
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddDbContext<WriteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ExceptionHandlerMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FullCqrsApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}