# 🧩 API de Gestión de Artículos 
API REST desarrollada con **ASP.NET Core** y **Entity Framework Core**, diseñada para administrar artículos, marcas y categorías de manera estructurada, escalable y mantenible. 
Este proyecto forma parte de mi práctica profesional en desarrollo **back-end**, siguiendo buenas prácticas de arquitectura, separación por capas y uso de **Entity Framework** para el acceso a datos.

---

## 🚀 Tecnologías utilizadas

- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **SQL Server**  
- **LINQ**  
- **Inyección de dependencias (DI)**  
- **Patrón Repository / Service Layer (aplicado en ArticuloService)**
 
    ---
  
  ## 🧱 Arquitectura del proyecto
  La solución está organizada por capas para favorecer la mantenibilidad y escalabilidad:
```
AppWeb.API
│
├── Controllers
│ └── ArticulosController.cs # Gestiona las peticiones HTTP
│
├── Business
│ └── ArticuloService.cs # Lógica de negocio 
│
├── Data
│ └── AppDbContext.cs 
│
├── Models
│ ├── Articulo.cs # Entidad principal
│ ├── Marca.cs # Entidad relacionada
│ └── Categoria.cs # Entidad relacionada
│
└── Program.cs 
```

---

## 📡 Endpoints principales

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/articulos` | Obtiene todos los artículos con su marca y categoría. |
| **GET** | `/api/articulos/filtrar` | Permite filtrar artículos por campo, criterio y valor. |
| **POST** | `/api/articulos` | Agrega un nuevo artículo. |
| **PUT** | `/api/articulos/{id}` | Modifica un artículo existente. |
| **DELETE** | `/api/articulos/{id}` | Elimina un artículo por su ID. |

Ejemplo de respuesta (GET `/api/articulos`):
 
> ```json
> [
>   {
>     "id": 1,
>     "nombre": "Notebook HP 15",
>     "descripcion": "Portátil con procesador Intel i5",
>     "precio": 799.99,
>     "imagenUrl": "https://ejemplo.com/hp15.jpg",
>     "marca": { "id": 1, "descripcion": "HP" },
>     "categoria": { "id": 1, "descripcion": "Informática" }
>   }
> ]
> ```

 ---
 
  ## ⚙️ Configuración del entorno
  1.Clonar el repositorio:  
  git clone https://github.com/octavioduartejurczyszyn/AppWeb.API.git
  2.Configurar la cadena de conexión en el archivo appsettings.json:  
 "ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=AppWebDB;Trusted_Connection=True;TrustServerCertificate=True;"
}  
  3.Aplicar las migraciones y crear la base de datos: dotnet ef database update  
  4.Ejecutar el proyecto:  
  dotnet run  
  5.Acceder a Swagger UI (documentación interactiva):  
  https://localhost:5001/swagger  
  
  ---
  
  ## Buenas prácticas aplicadas:  
  Separación por capas (Controller, Business, Data, Models).  
  Uso de Entity Framework Core con DbContext para el acceso a datos.   
  Inyección de dependencias configurada en Program.cs. Manejo de excepciones y validaciones básicas.   
  Código preparado para escalar a nuevas entidades o controladores.   
  
  👨‍💻 Autor Octavio Duarte  
  Desarrollador Back-End | .NET & C#  
  📍 Valencia, España  

  ⚠️ Este proyecto está configurado con EF Core y una base de datos local (LocalDB).
Si deseás ejecutarlo, solo necesitás tener instalado SQL Server Express o LocalDB.
En caso de solo revisar el código, no es necesario modificar la conexión: el código es funcional y sigue las buenas prácticas de EF Core.





  
