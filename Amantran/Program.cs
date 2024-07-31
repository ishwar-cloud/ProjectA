using Amantran.Interface;
using Amantran.Models;
using Amantran.Services;
using Microsoft.EntityFrameworkCore;

namespace Amantran
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
           
            builder.Services.AddDbContext<AmantranContext>(item => item.UseSqlServer(config.GetConnectionString("connString")));

            // Register the InvitationService
            builder.Services.AddScoped<IInvitaionSelection, InvitaionSelection>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
