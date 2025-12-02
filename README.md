# 🧩 AppWeb.API — API REST en ASP.NET Core 8 + SQL Server + EF Core

Este es un proyecto de API REST desarrollado con **ASP.NET Core 8**, siguiendo una arquitectura profesional basada en **capas**, con acceso a datos mediante **Entity Framework Core**, y documentada con **Swagger**.

Incluye CRUD completo para:

- **Artículos**
- **Categorías**
- **Marcas**

---

## 🚀 Tecnologías utilizadas

- **C# / .NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core 8**
- **SQL Server**
- **Swagger / Swashbuckle**
- **LINQ**
- **DTOs y Services por capas**
- **Arquitectura limpia por responsabilidad**

---

## 🧱 Arquitectura del proyecto

El proyecto está organizado en capas de manera clara y extensible:
 
```
AppWeb.API/
│
├── Controllers/
│ ├── ArticulosController.cs
│ ├── CategoriasController.cs
│ └── MarcasController.cs
│
├── Models/
│ ├── Articulo.cs
│ ├── Categoria.cs
│ ├── Marca.cs
│ └── DTOs/
│ ├── ArticuloDtos.cs
│ ├── CategoriaDtos.cs
│ └── MarcaDtos.cs
│
├── Services/
│ ├── IArticuloService.cs
│ ├── ICategoriaService.cs
│ ├── IMarcaService.cs
│ ├── ArticuloService.cs
│ ├── CategoriaService.cs
│ └── MarcaService.cs
│
├── Data/
│ └── AppDbContext.cs
├── Docs/
│ ├── Swagger.png
│ ├── Swagger1.png
│ └── Swagger2.png
│
├── appsettings.json
│
└── README.md
```

---

## 📡 Endpoints principales

### 🟦 Artículos

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/articulos` | Obtiene todos los artículos. |
| **GET** | `/api/articulos/{id}` | Obtiene un artículo por su ID. |
| **POST** | `/api/articulos` | Agrega un nuevo artículo. |
| **PUT** | `/api/articulos/{id}` | Modifica un artículo existente. |
| **DELETE** | `/api/articulos/{id}` | Elimina un artículo por su ID. |

---

### 🟧 Categorías

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/categorias` | Obtiene todas las categorías. |
| **GET** | `/api/categorias/{id}` | Obtiene una categoría por su ID. |
| **POST** | `/api/categorias` | Agrega una nueva categoría. |
| **PUT** | `/api/categorias/{id}` | Modifica una categoría existente. |
| **DELETE** | `/api/categorias/{id}` | Elimina una categoría por su ID. |

---

### 🟥 Marcas

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/marcas` | Obtiene todas las marcas. |
| **GET** | `/api/marcas/{id}` | Obtiene una marca por su ID. |
| **POST** | `/api/marcas` | Agrega una nueva marca. |
| **PUT** | `/api/marcas/{id}` | Modifica una marca existente. |
| **DELETE** | `/api/marcas/{id}` | Elimina una marca por su ID. |

---

## 🔍 Swagger

Swagger se habilita automáticamente al ejecutar el proyecto en modo Development.

URL típica:

https://localhost
:<puerto>/swagger
  
  ---

## ⚠️ Nota sobre la base de datos

Este proyecto utiliza una base de datos local preexistente llamada **CATALOGO_DB**, que contiene las tablas:

- Articulos  
- Categorias  
- Marcas  

Actualmente **no se incluye un script SQL** para crear estas tablas, ya que la base proviene de un proyecto anterior y fue reutilizada para esta API.

Por este motivo, **la API no puede ejecutarse directamente en otros ordenadores** sin recrear manualmente la estructura de la base de datos.

En la sección “Capturas de Swagger” se muestran pruebas reales de la API en funcionamiento.

---

## 👤 Autor

**Octavio Duarte**  
Desarrollador Back-End | .NET & C#  
📍 Valencia, España  






  
