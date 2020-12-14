using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebApplication2.Data;

namespace WebApplication2
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
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
			services.AddDbContext<LibraryContext>(options =>
			{
				options.UseMySql(Configuration.GetConnectionString("LocalMySql"));
			});

			services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddControllersWithViews();
			services.AddRazorPages().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseStatusCodePagesWithRedirects("/Error/{0}");

			app.UseHttpsRedirection();
			app.UseWebSockets();

			app.UseStaticFiles();
			//app.UseStaticFiles(new StaticFileOptions
			//{
			//	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
			//	RequestPath = "/node_modules"
			//});
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Download")),
				RequestPath = "/Download"
			});
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Image")),
				RequestPath = "/Image"
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseMvc(builder =>
			{
				builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
