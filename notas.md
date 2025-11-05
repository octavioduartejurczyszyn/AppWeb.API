                                                                 # 🧠 Notas Técnicas - Proyecto AppWeb

## 🧩 1. Arquitectura del Proyecto
**Objetivo general:**  
Pasar el proyecto de Artículos (app monolítica) a una API REST con ASP.NET Core, buscando hacerlo de una manera profesional y orientada a portfolio. Importante: 
todo lo que haga tiene que estar alineado  con lo que se usa hoy en el mercado laboral IT.

**Capas principales:**
- **Models:** clases que representan las entidades (tablas de la base de datos).
- **Business (o Services):** lógica de negocio, validaciones y reglas del dominio.
- **Data (si existe):** manejo de acceso a base de datos (consultas, conexiones, repositorios).
- **Controllers:** endpoints de la API que reciben y devuelven información en formato JSON.
- **Presentation (si aplica):** capa del front (si más adelante hacés una interfaz).

**Dependencias o librerías principales:**
- .NET / ASP.NET Core versión:  
- Entity Framework Core versión:  
- SQL Server versión:  
- Otras librerías:  

---

## ⚙️ 2. Buenas Prácticas que se están aplicando
- Separar las capas para mantener responsabilidad única.  
- Usar nombres claros y consistentes (por ejemplo: `ArticuloController`, `ArticuloService`).  
- Validar datos en la capa de negocio, no en el controlador.  
- Retornar respuestas HTTP adecuadas (`200 OK`, `400 BadRequest`, `404 NotFound`, `500 InternalServerError`).  
- Centralizar cadenas de conexión y configuraciones en `appsettings.json`.  
- Subir cambios con commits claros a GitHub (por ejemplo: `fix: endpoint de creación de artículos`).  

---

## 🧱 3. Conceptos Técnicos Aprendidos
Anotá acá las ideas clave que vas entendiendo del curso o de tu propio código:

- `[ApiController]`: indica que el controlador maneja peticiones HTTP y valida automáticamente los modelos. 
- `IActionResult`: permite devolver diferentes tipos de respuesta HTTP.  
- `Route("api/[controller]")`: genera rutas automáticamente según el nombre del controlador.  
- `JsonResult`: devuelve datos en formato JSON al cliente (front o Postman).  
- `Dependency Injection`: patrón para inyectar dependencias (como servicios o repositorios).  
- el `contenedor (o Dependency Injection Container)` es básicamente una clase/objeto que:
Se crea cuando arranca la aplicación,
Se mantiene “viva” durante toda su ejecución,
Y su tarea principal es crear y suministrar objetos a las clases que los necesitan.

---

## 🧰 4. Errores o Dificultades Encontradas
Anotá lo que te haya costado entender o errores que te sirvieron para aprender.

- Me daba error en las propiedades Sql porque no tenía descargado el paquete Nuget correspondiente
---

## 🚀 5. Pendientes / Próximos pasos
- [] Implementar los endpoints CRUD para `Articulo`.  
- [] Añadir validaciones en la capa Business.  
- [] Crear documentación Swagger.  
- [] Escribir pruebas unitarias básicas.  
- [] Hacer Readme para el proyecto en GitHub.
- [] Modificar la cadena de conexión dado que el nombre de la base de datos no es correcta.
- [OK] Me quedé en entender cómo e imaginarme que al crear un objeto de tipo ArticuloService, internamente se cree un objeto de tipo AppDbContext gracias a la inyección de dependencias. Quiero entender bien ese flujo.
- [] Analizar método Filtrar propuesto por ChatGPT.
- [] Continuar con que ChatGPT me analice el archivo y me haga la devolución.
- []Agregar validaciones básicas (p. ej. que Precio sea positivo, que Nombre no esté vacío).
- []Agregar DTOs para separar los modelos de dominio (Articulo) de los datos expuestos en la API.
- []Agregar un sistema de logging simple (por ejemplo, con ILogger<ArticuloService>).
- []Agregar tests unitarios (si querés dar un salto grande en profesionalismo).
- []Ver essrot que me recomnendó Chat: si las propiedades Marca y Categoria son entidades relacionadas ya existentes en la BD, lo ideal sería actualizar sus claves foráneas (por ejemplo IdMarca e IdCategoria) en lugar de reasignar las instancias
- []Mejora opcional (en el futuro): validar que no haya duplicados (por nombre o código).
- []
- []
- []
- []

## 💬 6. Cosas para investigar más adelante
- ¿Qué diferencia hay entre `IActionResult` y `ActionResult<T>`?  
- ¿Cómo funciona la inyección de dependencias en ASP.NET Core?  
- ¿Cómo desplegar una API en Azure o en un servidor propio?  
- ¿Qué son los DTOs y cuándo conviene usarlos?  

---

## 💬 7. Glosario de términos
- **API REST:** Interfaz de programación que sigue los principios REST para comunicación entre sistemas.
-  **ASP.NET Core:** Framework de Microsoft para construir aplicaciones web y APIs.
 - **Entity Framework Core:** ORM (Object-Relational Mapper) para trabajar con bases de datos en .NET.
 -**Controller:** Clase que maneja las solicitudes HTTP y devuelve respuestas.
 - **Dependency Injection  :** Patrón de diseño para gestionar dependencias entre clases.
 - **IActionResult:** Interfaz que representa el resultado de una acción en un controlador.
 - **JsonResult:** Clase que devuelve datos en formato JSON. 

## 📅 8. Registro de progreso

## 15/10/2025
Qué se hizo
Creación del proyecto y estructura de capas
Comentario:
Se analizó el tema de los controladores y también se empezó a usar el documento de notas 

## 16/10/2025 
Qué se hizo
Se modernizó el acceso a datos del proyecto AppWeb.API utilizando Entity Framework Core (EF Core) para reemplazar el manejo manual de consultas SQL y 
facilitar la interacción con la base de datos SQL Server. Ya no es necesario usar consultas SQL manuales ni la clase AccesoDatos.
Para esto:
1.Se añadieron  los paquetes NuGet  necesarios:
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools

2.Creación de la clase de contexto AppDbContext
Se agregó dentro de la carpeta Data
Esta clase actúa como intermediario entre las entidades del proyecto y la base de datos.
Se definieron los DbSet para las entidades principales:
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

3.Configuración de la cadena de conexión
    En appsettings.json se incorporó la sección ConnectionStrings para conectar con SQL Server. 
    El archivo appsettings.json es el archivo donde se guardan configuraciones globales, y entre ellas, la ConnectionString de la base de datos.
    Esta conexión se registró en Program.cs mediante inyección de dependencias.

## 17/10/2025 
Qué se hizo
Se entendió el rol de la clase Program.cs como punto de entrada y centro de configuración de servicios.
Se explicó el concepto de Inyección de Dependencias (DI) y por qué es una buena práctica frente a crear dependencias manualmente.
Se analizó cómo reemplazar la clase AccesoDatos por EF Core, eliminando la necesidad de consultas SQL manuales.
Para qué se hizo:
Modernizar el proyecto para seguir las prácticas actuales en .NET.
Desacoplar el código de la base de datos y facilitar el mantenimiento.
Preparar la arquitectura para que el proyecto funcione como una API REST moderna y escalable.

## 18/10/2025
Durante la jornada se trabajó en entender cómo se estructura la conexión a la base de datos dentro de un proyecto con Entity Framework Core y arquitectura en capas.
Se repasaron los siguientes puntos:
AppDbContext
Se explicó que esta clase actúa como el intermediario entre las entidades del proyecto y la base de datos.
Su función es leer, escribir, actualizar y eliminar datos en la base, traduciéndolos entre objetos de C# y tablas SQL.
Representa el “contexto” de trabajo con la base, es decir, el entorno donde EF sabe cómo acceder a las tablas.
appsettings.json
Se entendió que este archivo sirve para almacenar configuraciones globales del sistema, especialmente la cadena de conexión a la base de datos.
Permite modificar parámetros sin tener que recompilar el código, lo que lo hace ideal para configuraciones variables (servidor, puerto, claves, etc.).
Program.cs
Se explicó que es el punto de entrada del programa, donde se registran todos los servicios y dependencias que la aplicación necesita para funcionar.
Es también donde se configura la inyección de dependencias, registrando el AppDbContext y leyéndolo desde appsettings.json.
Se comprendió que este archivo es clave porque inicia el motor del programa y construye los servicios antes de que se ejecuten los controladores o las capas de negocio.
Inyección de dependencias
Se repasó el concepto de inyectar servicios o clases necesarias (como el AppDbContext) en lugar de crearlas manualmente con new.
Esto permite centralizar la configuración (si cambia la base, solo se modifica en appsettings.json y Program.cs), evitando repetir código y reduciendo errores.

## 21/10/2025
Se entendió qué son los servicios: clases que encapsulan funcionalidades que tu aplicación necesita usar repetidamente. Por ejemplo: un servivio que realiza operaciones sobre tu base de datos
Se aprendió el concepto de inyección de dependencias (DI), que permite que ASP.NET Core cree e inserte automáticamente los servicios cuando un controlador los necesita.
El flujo típico de una app web con ASP.NET Core es:
Cliente → Controller → Servicio (Negocio) → EF Core (Contexto) → Base de datos
Cada capa tiene una función clara:
El Controller recibe las peticiones HTTP.
El Servicio ejecuta la lógica de negocio.
EF Core maneja la conexión y las consultas a la base de datos.
Recorrí todo lo visto hasta el momento para asegurarme de entender cómo se conectan las piezas.
Definición de API REST: es una interfaz de programación que sigue los principios de arquitectura de software REST (Transferencia de Estado Representacional).
Su objetivo es facilitar la comunicación entre sistemas a través de internet, utilizando el protocolo HTTP.  
Definición de servicios: es una clase que encapsula una funcionalidad que tu aplicación necesita usar repetidamente. Por ejemplo: un servivio que realiza operaciones sobre tu base de datos

## 27/10/2025
Qué se hizo
Se le aagregó el Id a la clase Marca y Categoria para que funcione correctamente con Entity Framework Core (EF Core) y también porque es la forma más segura y típica en APIs REST.
Por lo tanto, en modificar se le agregó nuevo código para que no lance una excpención por null. Lo mismo en eliminar.
Se agregó MarcaId y CategoriaId en la calse Articulo, de esta manera evitás cargar objetos completos y podés trabajar con los IDs directamente.

## 29/10/2025
Qué se hizo
Se entendió a el funcionamiento de una propiedad Private. Se entendió que con el operador de acceso al miembor no se puede acceder a una propiedad privada.
Que esta misma solo se puede modificar con propiedades públicas o métdodos ´públicos.
Se entendió la diferencia de importancia de una clase Program de un programa de consola y una clase Program de un proyecto ASP.NET Core.
Se aprendió que en proyectos ASP. NET Core ya no codifico la creación de objetos, sino que los crea y administra el framwork usando el contenedor de dependencias (DI)
Se aprendió profundamente qué es y cómo se usa el contenedor de dependencias (DI Container).





