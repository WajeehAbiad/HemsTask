using HemsTask.DataAccess.Infrastructure;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using HemsTask.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;

namespace ProfileTask
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
			services.AddControllersWithViews();

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection"));
			});

			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				//app.UseExceptionHandler("/Home/Error");

				app.UseExceptionHandler(options =>
				{
					options.Run(
						async context =>
						{
							context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
							context.Response.ContentType = "text/html";
							var ex = context.Features.Get<IExceptionHandlerFeature>();
							if (ex != null)
							{
								var err = $"<h3>{ex.Error.Message}</h3> <a href=\"\">back</a>";
								await context.Response.WriteAsync(err).ConfigureAwait(false);
							}
						});
				});

				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseGlobalExceptionMiddleware();

			app.UseWhen(context => true, appBuilder =>
			{
				appBuilder.UseStatusCodePagesWithReExecute("/Errors/Error/{0}");
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
