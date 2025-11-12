# 💀 Northwind.Web - Blazor WebAssembly Demo 🌺

## Presentación: "Blazor y .NET 10: Construcción de Aplicaciones Modernas Directamente en el Navegador"

### 📚 Universidad Autónoma de Chiapas
**Proyecto de demostración desarrollado para ilustrar las capacidades de Blazor WebAssembly con .NET 10**

---

## 🎯 Descripción del Proyecto

Este proyecto es una aplicación web moderna desarrollada con **Blazor WebAssembly** y **.NET 10** que demuestra cómo construir aplicaciones web completas que se ejecutan completamente en el navegador del cliente, sin necesidad de renderizado del lado del servidor para cada interacción.

La aplicación está tematizada con el **Día de Muertos** mexicano (Judit Coco Fest) y presenta un sistema de gestión de categorías y productos, implementando una arquitectura limpia y modular siguiendo principios SOLID y patrones de diseño modernos.

---

## 🏗️ Arquitectura del Proyecto

El proyecto sigue una **arquitectura vertical slice** combinada con **separación de responsabilidades** mediante capas lógicas:

```
Northwind.Web/
│
├── 📱 Northwind.Web (Host Principal - Blazor WASM)
│   ├── Program.cs - Configuración y punto de entrada
│   ├── App.razor - Enrutamiento principal
│   └── Pages/ - Páginas de la aplicación
│
├── 📦 CategoryManager/ (Feature Slice - Categorías)
│   ├── CategoryManager.Views - Componentes Razor
│   ├── CategoryManager.ViewModels - Lógica de presentación
│   └── CategoryManager.Proxy - Comunicación con API
│
├── 📦 ProductManager/ (Feature Slice - Productos)
│   ├── ProductManager.Views - Componentes Razor
│   ├── ProductManager.ViewModels - Lógica de presentación
│   └── ProductManager.Proxy - Comunicación con API
│
└── 🔧 Common/
    └── Domain/ - DTOs y objetos de dominio compartidos
```

### 🎨 Características de la Arquitectura

1. **Vertical Slice Architecture**: Cada feature (CategoryManager, ProductManager) contiene toda su funcionalidad en módulos independientes
2. **Separation of Concerns**: Separación clara entre Views, ViewModels y Proxies
3. **Dependency Injection**: Uso extensivo de DI para gestión de dependencias
4. **Domain-Driven Design**: DTOs y objetos de valor en el dominio común

---

## 🚀 Tecnologías Utilizadas

### Framework y Plataforma
- **.NET 10.0** (RC 2)
- **Blazor WebAssembly** - Framework para ejecutar .NET en el navegador vía WebAssembly
- **C# 13** - Último estándar del lenguaje

### Paquetes NuGet Principales
```xml
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly" Version="10.0.0-rc.2.25502.107" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.DevServer" Version="10.0.0-rc.2.25502.107" />
```

### Frontend
- **Tailwind CSS** - Framework CSS para diseño moderno y responsivo
- **Service Workers** - Para soporte PWA (Progressive Web App)
- **Razor Components** - Componentes reutilizables de Blazor

### Integración Backend
- **HttpClient** - Para comunicación con API REST
- **JSON Serialization** - Para intercambio de datos
- **Azure Web Apps** - API hospedada en Azure

---

## 📋 Componentes Principales

### 1. **CategoryManager** - Gestión de Categorías

#### CategoryManager.Proxy
**Responsabilidad**: Comunicación con la API REST para operaciones CRUD de categorías.

**Clase Principal**: `CategoryProxy.cs`
```csharp
- GetAllCategoriesAsync() - Obtiene todas las categorías
- AddCategoryAsync() - Crea una nueva categoría
- UpdateCategoryAsync() - Actualiza una categoría existente
- DesactivateCategoryAsync() - Desactiva una categoría
```

**Patrón**: Proxy Pattern para abstraer la comunicación HTTP.

#### CategoryManager.ViewModels
**Responsabilidad**: Lógica de presentación y estado de la UI.

**ViewModels**:
- `SearchCategoryViewModel` - Gestión de búsqueda y listado
- `ActionCategoryViewModel` - Gestión de creación y edición

**Patrón**: MVVM (Model-View-ViewModel)

#### CategoryManager.Views
**Responsabilidad**: Interfaz de usuario y componentes visuales.

**Página Principal**: `CategoryPage.razor`
- CRUD completo de categorías
- Modales para crear y editar
- Confirmación de desactivación
- Notificaciones toast
- Diseño responsivo (móvil/desktop)

### 2. **ProductManager** - Gestión de Productos

Estructura similar a CategoryManager, siguiendo el mismo patrón arquitectónico.

### 3. **Common/Domain** - Capa de Dominio

**DTOs (Data Transfer Objects)**:
```csharp
CategoryDto
{
    int Id
    string Name
    string Description
    bool IsActive
}
```

**Value Objects**:
- `HandlerRequestResult` - Envoltorio para respuestas de API
- `HandlerRequestResult<T>` - Versión genérica

---

## 🎨 Características de la Interfaz

### Diseño Temático - Día de Muertos

La aplicación presenta un diseño visualmente atractivo con:

- 🎨 **Paleta de Colores**: Naranjas, rosas, morados y amarillos vibrantes
- 💀 **Iconografía**: Emojis temáticos del Día de Muertos
- 🌺 **Gradientes**: Efectos degradados en botones y encabezados
- ✨ **Animaciones**: Transiciones suaves y efectos hover
- 📱 **Responsividad**: Diseño adaptativo móvil-first

### Componentes UI

1. **Landing Page (Home.razor)**
   - Presentación del evento "Judit Coco Fest"
   - Información del Día de Muertos
   - Navegación a categorías

2. **Category Management**
   - Tabla responsiva (desktop)
   - Tarjetas (móvil)
   - Modales interactivos
   - Validación de formularios
   - Feedback visual (toasts)

---

## 🔧 Configuración y Ejecución

### Prerequisitos

- Visual Studio 2026
- .NET 10.0 SDK (RC 2 o superior)
- Navegador moderno con soporte WebAssembly

### Configuración del Proyecto

1. **Clonar el repositorio**
```powershell
git clone https://github.com/NetDanydrago/Northwind.Chiapas.git
cd Northwind.Web
```

2. **Configurar la API Backend**

Editar `wwwroot/appsettings.json`:
```json
{
  "WebApiAddress": "https://apinorthwind20251012132800.azurewebsites.net/"
}
```

3. **Restaurar dependencias**
```powershell
dotnet restore
```

4. **Ejecutar la aplicación**
```powershell
dotnet run --project Northwind.Web/Northwind.Web.csproj
```

O desde Visual Studio:
- Abrir `Northwind.Web.slnx`
- Presionar F5 o hacer clic en "Run"

---

## 🏛️ Patrones de Diseño Implementados

### 1. **Dependency Injection (DI)**
Cada módulo expone un `DependencyContainer` para registrar servicios:

```csharp
// CategoryManager.Proxy
services.AddCategoryManagerProxies(proxy => 
{
    proxy.BaseAddress = new Uri(configuration["WebApiAddress"]);
});

// CategoryManager.ViewModels
services.AddCategoryManagerViewModels();
```

### 2. **Proxy Pattern**
`CategoryProxy` actúa como intermediario entre la aplicación y la API:
- Encapsula lógica HTTP
- Manejo centralizado de errores
- Logging integrado

### 3. **MVVM (Model-View-ViewModel)**
Separación clara:
- **Model**: DTOs en `Domain`
- **View**: Componentes `.razor`
- **ViewModel**: Lógica de presentación


### Endpoints Consumidos

```
GET    /api/categories          - Listar categorías
POST   /api/categories          - Crear categoría
PUT    /api/categories          - Actualizar categoría
DELETE /api/categories/{id}     - Desactivar categoría
```

### Manejo de Errores

Cada operación incluye:
- Try-catch con logging
- Validación de respuestas
- Propagación controlada de excepciones

---

## 📱 Progressive Web App (PWA)

El proyecto incluye soporte PWA con:

### Service Worker
- **Archivo**: `service-worker.js` (desarrollo)
- **Archivo**: `service-worker.published.js` (producción)

### Manifest
- **Archivo**: `manifest.webmanifest`
- Permite instalar la app como nativa
- Soporte offline

### Configuración
```xml
<ServiceWorkerAssetsManifest>service-worker-assets.js</ServiceWorkerAssetsManifest>
```


## 🎓 Conceptos Educativos Demostrados

### 1. **Blazor WebAssembly vs Server**
- Ejecución 100% en el cliente
- Sin postbacks al servidor
- Mejor experiencia de usuario
- Reducción de carga del servidor

### 2. **Componentes Razor**
- Sintaxis declarativa
- Data binding bidireccional
- Ciclo de vida de componentes
- Event handling

### 3. **Enrutamiento en SPA**
```csharp
<Router AppAssembly="@typeof(App).Assembly" 
        AdditionalAssemblies="AdditionalAssemblies">
```

### 4. **Carga de Módulos Dinámicos**
```csharp
Assembly[] AdditionalAssemblies =>
    new Assembly[]
    {
        typeof(CategoryManager.Views.Pages.CategoryPage).Assembly,
        typeof(ProductManager.Views.Pages.ProductPage).Assembly
    };
```

### 5. **Formularios y Validación**
```html
<EditForm Model="ActionCategoryViewModel.Category" OnValidSubmit="CreateAsync">
    <DataAnnotationsValidator />
    <ValidationMessage For="() => ActionCategoryViewModel.Category.Name" />
</EditForm>
```

## 🎯 Ventajas de Blazor WebAssembly

### ✅ Ventajas

1. **Desarrollo Full-Stack en C#**: No necesitas JavaScript
2. **Reutilización de Código**: Compartir lógica entre cliente y servidor
3. **Performance**: Ejecución nativa en el navegador
4. **Experiencia de Usuario**: SPA sin recargas de página
5. **Tooling**: IntelliSense completo de Visual Studio
6. **Type Safety**: Tipado fuerte end-to-end
7. **PWA Support**: Aplicaciones instalables y offline

---


## 📚 Recursos Adicionales

### Documentación Oficial

- [Blazor Docs](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [.NET 10 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- [WebAssembly](https://webassembly.org/)


## 👥 Créditos

**Presentación**: Universidad Autónoma de Chiapas  
**Tema**: Blazor y .NET 10: Construcción de Aplicaciones Modernas Directamente en el Navegador  

---

## 📄 Licencia

Este proyecto es material educativo desarrollado para fines de demostración y enseñanza.

---

## 🎓 Conclusiones de la Presentación

### ¿Por qué Blazor?

1. **Unificación Tecnológica**: Un solo lenguaje (C#) para todo el stack
2. **Productividad**: Reutilización de conocimientos y código
3. **Rendimiento**: Compilado a WebAssembly nativo
4. **Ecosistema**: NuGet, Visual Studio, .NET Libraries
5. **Futuro**: Microsoft invierte fuertemente en Blazor

### Casos de Uso Ideales

- ✅ Aplicaciones empresariales internas
- ✅ Dashboards y herramientas administrativas
- ✅ PWAs con funcionalidad offline
- ✅ Sistemas con equipos .NET existentes
- ✅ Aplicaciones con lógica compleja del lado cliente

---

**¡Gracias por explorar este proyecto! 💀🌺**
