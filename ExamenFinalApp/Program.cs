using ExamenFinalApp.Client.Pages;
using ExamenFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient(); 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
});


builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAntiforgery();


app.MapControllers();
app.MapStaticAssets(); 
app.MapFallbackToFile("index.html"); 

app.Run();
