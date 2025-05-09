
# 📌 Instalación

## Requisitos Previos:

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- SQL Server Express (o LocalDB)
- Node.js *(opcional para herramientas frontend)*

## Pasos de Configuración:

```bash
# Clonar el repositorio
git clone https://github.com/tu-repositorio/ExamenFinalApp.git

# Restaurar dependencias
dotnet restore

# Ejecutar migraciones de EF Core
dotnet ef database update

# Iniciar la aplicación
dotnet run
```

---

# 📌 Configuración PWA

### Archivos clave:

* `manifest.json`: metadatos de la aplicación.
* `service-worker.js`: manejo de caché y recursos offline.
* `wwwroot/`: contiene recursos estáticos (CSS, JS, imágenes).

---

# 📌 Uso Básico

## Agregar un libro:

1. Completa el formulario.
2. Haz clic en **Guardar**.
3. Se muestra una alerta verde de confirmación.

## Editar / Eliminar:

* Usa los botones:

  * ✏️ (amarillo) para editar.
  * 🗑️ (rojo) para eliminar.

---

# 🧾 Comentarios XML en Código Clave

## 🔹 En `LibroController.cs`

```csharp
/// <summary>
/// Controlador API para operaciones CRUD de libros.
/// </summary>
/// <remarks>
/// Endpoints:
/// - GET /api/Libro → Lista todos los libros.
/// - POST /api/Libro → Agrega un nuevo libro.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class LibroController : ControllerBase { ... }
```

## 🔹 En `Home.razor` (Blazor)

```csharp
@code {
    /// <summary>
    /// Obtiene la lista de libros desde la API.
    /// </summary>
    /// <returns>Task con la operación asíncrona.</returns>
    async Task ObtenerLibros() {
        libros = await Http.GetFromJsonAsync<List<Libro>>($"{url}/api/Libro");
    }
}
```

---

# 🎥 Video Tutorial de Instalación/Uso

**Incluye:**

✅ Instalación:

* Configuración de la base de datos.
* Ejecución de migraciones.

✅ Funcionalidades CRUD:

* Demo de agregar, editar y eliminar libros.
* Visualización de alertas (verde, amarillo, rojo).

✅ Instalación como PWA:

* Añadir app al escritorio desde Chrome/Edge.

---

# 🛠️ Soporte Técnico

## 1. Formulario de Contacto Ficticio

```razor
<EditForm Model="@problema" OnValidSubmit="@EnviarReporte">
    <InputText @bind-Value="problema.Descripcion" placeholder="Describe el error..." />
    <button type="submit" class="btn btn-primary">Enviar</button>
</EditForm>

@code {
    class Problema { public string Descripcion { get; set; } = ""; }
    Problema problema = new();

    void EnviarReporte() {
        // Simulación de envío (no implementado en producción)
        Console.WriteLine($"Reporte enviado: {problema.Descripcion}");
    }
}
```

---

## 2. FAQ en Código (Comentarios)

### 🔹 En `Program.cs`

```csharp
// ⚠️ FAQ: ¿Cómo solucionar errores de CORS?
// Asegurar que el cliente y el servidor usen la misma URL.
// Ejemplo: builder.Services.AddCors(options => options.AddPolicy("AllowAll", ...));
```

### 🔹 En `service-worker.js`

```javascript
// ⚠️ FAQ: ¿La PWA no se actualiza?
// Borrar caché manualmente en DevTools → Application → Clear storage.
```
