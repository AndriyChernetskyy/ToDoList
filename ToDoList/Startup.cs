using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Commands.Plan.Create;
using ToDoList.Commands.Plan.Delete;
using ToDoList.Commands.Plan.Update;
using ToDoList.Models;
using ToDoList.Queries.Plan.Get;

namespace ToDoList
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
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddDbContext<PlannerContext>(context => context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Register();

            services.AddMediatR(typeof(GetPlansQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreatePlanCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeletePlanCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePlanCommandHandler).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:52427"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
