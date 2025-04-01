
# 🎓 ExamenFinalApp

Aplicación desarrollada con **Blazor WebAssembly**, **.NET 9**, **Entity Framework Core** y **SQL Server** para el examen final del curso de **Programación Multiplataforma**.

Permite realizar operaciones CRUD sobre una tabla de libros, con validaciones, diseño responsivo y soporte PWA.

---

## 🚀 Características

- Agregar, editar, listar y eliminar libros 📚
- Validación de formularios con DataAnnotations
- Formato de fecha personalizado (`dd/MM/yyyy`)
- Alertas visuales según acción (agregar, editar, eliminar)
- Carga animada (spinner) y diseño responsivo con Bootstrap
- Implementación de PWA (instalable como app)
- Bootstrap 5.3 integrado vía CDN
- Arquitectura en capas (Client, Server, Shared)
- Migraciones automáticas con EF Core

---

## 🛠️ Tecnologías utilizadas

- Blazor WebAssembly (.NET 9)
- ASP.NET Core + API REST
- Entity Framework Core
- SQL Server Express
- Bootstrap 5.3 (CDN)
- Visual Studio 2022
- Git + GitHub

---

## 📦 Estructura del Proyecto

```plaintext
ExamenFinalApp.sln
│
├── ExamenFinalApp/             → Proyecto del servidor (API + EF Core)
│   ├── Data/
│   ├── Controllers/
│   └── Migrations/
│
├── ExamenFinalApp.Client/      → Proyecto Blazor WebAssembly (PWA)
│   └── Pages/Home.razor
│
├── ExamenFinalApp.Shared/      → Proyecto compartido (modelo Libro.cs)
│   └── Models/Libro.cs
```

---

## 🧪 Requisitos

- .NET 9 SDK  
- SQL Server Express o LocalDB  
- Visual Studio 2022 con soporte para .NET, Blazor y EF Core

---

## 💾 Instalación local

### 1. Clonar el repositorio

```bash
git clone https://github.com/matryx-root/ExamenFinalApp.git
cd ExamenFinalApp
```

### 2. Configurar la cadena de conexión

En el archivo `appsettings.json` del proyecto **ExamenFinalApp**:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\SQLEXPRESS;Database=BiblioNet;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Ejecutar migraciones

```bash
dotnet ef database update --project ExamenFinalApp
```

### 4. Ejecutar el cliente (Blazor WebAssembly)

```bash
dotnet run --project ExamenFinalApp.Client
```

### 5. Acceder desde el navegador

```
https://localhost:5001
```

---

## 🧠 Créditos

Desarrollado por **Simón Sebastián Velásquez Cárcamo**  
Curso: *2025-1B - Programación Multiplataforma - IPLACEX*  
Docente: *Alondra Stephanie Vásquez Pereira*

---
