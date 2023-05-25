using CiudadanosSanos.Data;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<CSanosContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CSanosDB"))
            );

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}