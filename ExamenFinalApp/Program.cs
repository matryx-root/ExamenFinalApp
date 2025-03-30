using ExamenFinalApp.Client.Pages;
using ExamenFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Servicios
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient(); // Necesario para llamadas desde el server si las hay

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
});

// Habilita renderizado interactivo si se usan componentes dinámicos en el futuro
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// 🧱 Middleware
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAntiforgery();

// 🗺️ Rutas
app.MapControllers();
app.MapStaticAssets(); // Importante para Blazor WASM
app.MapFallbackToFile("index.html"); // Carga App.razor desde wwwroot/index.html

app.Run();
