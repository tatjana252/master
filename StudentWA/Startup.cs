using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.DTO;
using Data.EF;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.AutoMapper;
using WA2.Models;

namespace StudentWA
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProfessorProfile>();
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<GradeProfile>();
                cfg.AddProfile<SubjectProfile>();
                cfg.AddProfile<PersonProfile>();
                cfg.CreateMap<CityDTO, CityViewModel>().ReverseMap();
                cfg.CreateMap<City, CityViewModel>().ReverseMap();
                cfg.CreateMap<StudentDTO, StudentViewModel>();
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<StudentViewModel, StudentDTO>();
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<StudentViewModel, Student>();
                cfg.CreateMap<PersonViewModel, Person>();
                cfg.CreateMap<CityViewModel, City>();
                
            });
            services.AddDbContext<MASV2Context>();
            services.AddScoped<CityService>();
            services.AddScoped<ProfessorService>();
            services.AddScoped<StudentService>();
            services.AddScoped<SubjectService>();
            services.AddScoped<DBManagerUOW>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
