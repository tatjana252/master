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
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service;
using Service.AutoMapper;

namespace WebService
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
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfile<ProfessorProfile>();
				cfg.AddProfile<StudentProfile>();
				cfg.AddProfile<GradeProfile>();
				cfg.AddProfile<SubjectProfile>();
				cfg.AddProfile<PersonProfile>();
			});

			services.AddMvc().AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
			services.AddDbContext<MASV2Context>();
			services.AddScoped<ProfessorService>();
			services.AddScoped<ServiceBase<Student>, StudentService>();
			services.AddScoped<ServiceBase<Subject>, SubjectService>();
			services.AddScoped<ServiceBase<CityDTO>, CityService>();
			services.AddScoped<DBManagerUOW>();
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
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
