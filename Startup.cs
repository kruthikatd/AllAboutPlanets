
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AllAboutPlanets.API.Domain.Repository;
using AllAboutPlanets.API.Domain.Services;
using AllAboutPlanets.API.Persistence.Contexts;
using AllAboutPlanets.API.Persistence.Repository;
using AllAboutPlanets.API.Services;
using AutoMapper;

namespace AllAboutPlanets.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("AllAboutPlanets-api-in-memory");
            });

            services.AddScoped<IAllThePlanets, PlanetsService>();
            services.AddScoped<IPlanetDetailsRepository, PlanetsDetailsRepository>();


            services.AddScoped<IAllThePlanets, PlanetsService>();
            services.AddScoped<IPlanetsDetailsService, PlanetDetailsService>();


            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

        }
    }
}