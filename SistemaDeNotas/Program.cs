
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string SistemaDeNotas = builder.Configuration.GetConnectionString("DataBase");

            builder.Services.AddDbContextPool<BancoContext>(o => o.UseSqlServer(SistemaDeNotas));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<INotaRepositorio, NotaRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddScoped<IAvisosRepositorio, AvisosRepositorio>();

            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });


            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseCors(options =>
            {
                options.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            });

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}