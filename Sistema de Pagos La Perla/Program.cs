using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Data;
using Sistema_de_Pagos_La_Perla.Repositories;
using Sistema_de_Pagos_La_Perla.Models;
using Sistema_de_Pagos_La_Perla.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GestionPagosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository<Fundo>, FundoRepository>();
builder.Services.AddScoped<FundoService>();
builder.Services.AddScoped<TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();


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
