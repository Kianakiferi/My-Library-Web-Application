using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3
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
			services.AddDbContext<AccountContext>(options =>
				options.UseMySql(Configuration.GetConnectionString("LocalMySql")));

			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<AccountContext>();

			services.Configure<IdentityOptions>(options =>
			{
				//TODO Enable Lowercase NonAlphanumeric Uppercase
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 0;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 6;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-_+=~`!@#$%^&*()[]{};':\",./<>?\\|";
				options.User.RequireUniqueEmail = false;
			});

			services.AddDbContext<LibraryContext>(options =>
				options.UseMySql(Configuration.GetConnectionString("LocalMySql")));

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
				app.UseDatabaseErrorPage();
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
