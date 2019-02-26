using System;
using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Services;
using IncidentManagement.Repository;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;
using IncidentManagement.Repository.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace IncidentManagement
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
           services.AddAutoMapper();
           services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var sqlServer = Configuration.GetConnectionString("SqlServer");
            services.AddDbContext<RepositoryContext>(options => 
            options.UseSqlServer(sqlServer));
            services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            builder.AllowAnyHeader()
            .AllowAnyOrigin()));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IIncidentService, IncidentService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IMachineService, MachineService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IIncidentRepository, IncidentRepository>();
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IUserTypeRepository, UserTypeRepository>();    
            services.AddSwaggerGen(c =>
            { c.SwaggerDoc("v1", new Info { Title = "Incident Manager API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseCors();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incident Manager API v1");
            });
            app.UseMvc();
        }
    }
}
