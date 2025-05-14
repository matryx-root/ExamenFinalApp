// ⚠️ FAQ: ¿Cómo solucionar errores de CORS?
// Asegurar que el cliente y el servidor usen la misma URL.
/// Errores de CORS  
/// **Síntoma**:  
/// `Access - Control - Allow - Origin` bloqueado.
/// * *Solución * *:  
/// ```csharp
/// En Program.cs (Backend)
/// builder.Services.AddCors(options =>
///    options.AddPolicy("AllowAll", policy =>
///        policy.WithOrigins("https://localhost:5001") // ← URL del cliente
///              .AllowAnyMethod()
///               .AllowAnyHeader()));




using ExamenFinalApp.Client.Pages;
using ExamenFinalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

public class CustomDateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("dd/MM/yyyy"));
    }
}