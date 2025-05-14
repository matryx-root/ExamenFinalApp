
# 📚 Biblioteca Escolar - Examen Final  

Aplicación PWA para gestión de libros en la escuela "William Wallace", desarrollada con:  
- **Frontend**: Blazor WebAssembly (.NET 9)  
- **Backend**: API REST con .NET 9  
- **Base de Datos**: SQL Server Express  

## 🚀 Instalación  
1. **Clonar repositorio**:  
   ```bash
   git clone https://github.com/matryx-root/ExamenFinalApp.git
   ```
2. **Configurar BD**:  
   - Ejecutar migraciones:  
     ```bash
     dotnet ef database update --project ExamenFinalApp.Server
     ```
3. **Iniciar aplicación**:  
   ```bash
   dotnet run --project ExamenFinalApp.Server
   ```
4. **Acceder**:  
   Abrir `https://localhost:5001` en el navegador.  

## 📖 Manual de Uso  
### Operaciones CRUD:  
- **Agregar libro**: Rellenar formulario y guardar (✅ Alerta verde).  
- **Editar/Eliminar**: Usar botones en la tabla (⚠️ Alerta amarilla/🔴 roja).  
- **Instalar PWA**: Click en "Instalar" en el navegador (Chrome/Edge).  

## 📦 Estructura del Proyecto  
```
ExamenFinalApp/
├── Client/    # Blazor WASM
├── Server/    # API .NET
├── Shared/    # Modelos (Libro.cs)
└── README.md  # Este archivo
```

# 💾 Restauración de Base de Datos  

## Método 1: SSMS (GUI)  
1. Abrir **SQL Server Management Studio**.  
2. Click derecho en `BiblioNet` > `Tasks` > `Restore` > `Database`.  
3. Seleccionar archivo `.bak` y ejecutar.  

## Método 2: Script SQL  
```sql
RESTORE DATABASE BiblioNet
FROM DISK = 'C:\backups\BiblioNet_20250520.bak'
WITH REPLACE, RECOVERY;
```

## Automatización (PowerShell)  
```powershell
# Ejecutar cada 24h
Backup-SqlDatabase -ServerInstance "localhost\SQLEXPRESS" -Database "BiblioNet" -BackupFile "C:\backups\BiblioNet_$(Get-Date -Format yyyyMMdd).bak"
```

# 📝 Registro de Logs  

## Configuración en .NET  
```csharp
// En Program.cs
builder.Logging.AddFile("logs/app-{Date}.log", minimumLevel: LogLevel.Debug);
```

## Ejemplo de Consulta  
```sql
-- Buscar errores en SQL Server
SELECT * FROM sys.event_log 
WHERE message LIKE '%Error%' 
AND timestamp > DATEADD(day, -1, GETDATE());
```

## Script para Limpieza (Windows Task Scheduler)  
```powershell
# Eliminar logs antiguos (>30 días)
Get-ChildItem "C:\logs\*.log" | Where-Object { $_.LastWriteTime -lt (Get-Date).AddDays(-30) } | Remove-Item
```


## 📞 Soporte  
¿Problemas? Consulta las [FAQs en el código](#) o abre un *issue* en GitHub.  
