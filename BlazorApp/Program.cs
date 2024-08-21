using BlazorApp.Components;
using BlazorApp.DataAccess;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<UserGroupsContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

            builder.Services.AddHttpClient("Client", c => c.BaseAddress = new Uri("http://localhost:5019/"));

            // builder.Services.AddScoped<PermissionGroupAccessLayer>();
            builder.Services.AddScoped<IPermissionGroupAccessLayer, PermissionGroupAccessLayer>();
            builder.Services.AddScoped<IGroupRightAccessLayer, GroupRightAccessLayer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapControllers();

            // app.MapGet("/asd", () => "Hello World");

            app.Run();
        }
    }
}
