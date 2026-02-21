# 🏢 Sistema de Control de Personal — SisPersonal

> Aplicación de escritorio desarrollada en **C# .NET Framework 4.8** con arquitectura en capas (N-Tier) para la gestión integral de empleados, usuarios y marcaciones de asistencia.

---

## 📋 Tabla de Contenidos

- [Descripción General](#-descripción-general)
- [Tecnologías y Requisitos](#-tecnologías-y-requisitos)
- [Arquitectura del Sistema](#-arquitectura-del-sistema)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Módulos del Sistema](#-módulos-del-sistema)
- [Entidades de Datos](#-entidades-de-datos)
- [Base de Datos](#-base-de-datos)
- [Configuración e Instalación](#-configuración-e-instalación)
- [Pruebas Unitarias](#-pruebas-unitarias)
- [Patrones de Diseño](#-patrones-de-diseño)
- [Principios SOLID](#-principios-solid)
- [Paquetes NuGet](#-paquetes-nuget)
- [Capturas del Sistema](#-capturas-del-sistema)

---

## 📌 Descripción General

**SisPersonal** es un sistema de gestión de recursos humanos de escritorio que permite controlar:

- ✅ **Empleados** — Registro completo con foto, datos personales y remuneración
- ✅ **Usuarios** — Administración de accesos con perfiles y autenticación
- ✅ **Marcaciones de Asistencia** — Registro de entrada, salida y refrigerio
- ✅ **Reportes** — Generación de reportes en pantalla y exportación a PDF
- ✅ **Autenticación** — Sistema de login con control de perfiles y roles

El sistema implementa operaciones **CRUD completas** para cada módulo, respaldadas por **procedimientos almacenados** en SQL Server y una arquitectura en capas con soporte de pruebas unitarias automatizadas.

---

## 🛠️ Tecnologías y Requisitos

### Requisitos del Entorno

| Componente | Versión Mínima |
|---|---|
| Windows | Windows 10 / Windows Server 2016 |
| .NET Framework | **4.8** |
| Visual Studio | 2019 / 2022 |
| SQL Server | 2016 o superior |
| SQL Server Management Studio | Opcional (recomendado) |

### Stack Tecnológico

| Capa | Tecnología |
|---|---|
| Plataforma | C# — .NET Framework 4.8 |
| Interfaz de usuario | Windows Forms |
| Acceso a datos | ADO.NET + SqlClient |
| Base de datos | Microsoft SQL Server |
| Reportes | Microsoft ReportViewer 15.x (`.rdlc`) |
| Generación PDF | iTextSharp 5.5.13.4 |
| Criptografía | BouncyCastle.Cryptography 2.5.0 |
| Pruebas unitarias | NUnit 3.13.3 + Moq 4.20.69 |

---

## 🏗️ Arquitectura del Sistema

El sistema implementa una **Arquitectura en Capas (N-Tier)** con dependencias estrictamente unidireccionales:

```
┌──────────────────────────────────┐
│          CAPA GUI                │
│    (Windows Forms — Presentación)│
└──────────────┬───────────────────┘
               │ usa
               ▼
┌──────────────────────────────────┐
│        CAPA DE NEGOCIO (BL)      │
│      (Reglas y validaciones)     │
└──────────────┬───────────────────┘
               │ usa
               ▼
┌──────────────────────────────────┐
│    CAPA DE ACCESO A DATOS (CAD)  │
│   (ADO.NET + Stored Procedures)  │
└──────────────┬───────────────────┘
               │ usa
               ▼
┌──────────────────────────────────┐
│     CAPA DE ENTIDADES (CE)       │
│     (POCOs — Modelos de datos)   │
└──────────────────────────────────┘

┌──────────────────────────────────┐
│       CAPA DE PRUEBAS (Tests)    │
│    (NUnit + Moq — TDD)           │
└──────────────────────────────────┘
```

### Flujo de Datos

```
Usuario ──► GUI ──► BL ──► CAD ──► SQL Server
  ▲                                    │
  └────────── CE (Entidades) ◄─────────┘
```

---

## 📁 Estructura del Proyecto

```
SisPersonal/
│
├── 📂 CE/                          # Capa de Entidades (Common Entities)
│   ├── E_Empleado.cs               # Entidad Empleado (hereda de E_Marcaciones)
│   ├── E_Marcaciones.cs            # Entidad base de Marcaciones
│   └── E_Usuario.cs                # Entidad Usuario del sistema
│
├── 📂 CAD/                         # Capa de Acceso a Datos (Data Access Layer)
│   ├── Conexion.cs                 # Gestión de la cadena de conexión
│   ├── D_Conexion.cs               # Configuración de conexión alternativa
│   ├── D_Empleado.cs               # CRUD para Empleados (SP)
│   ├── D_Marcaciones.cs            # CRUD para Marcaciones (SP)
│   ├── D_Usuario.cs                # CRUD para Usuarios (SP)
│   ├── ID_Empleado.cs              # Interface de D_Empleado (para testing)
│   ├── ID_Marcaciones.cs           # Interface de D_Marcaciones (para testing)
│   └── ID_Usuario.cs               # Interface de D_Usuario (para testing)
│
├── 📂 BL/                          # Capa de Lógica de Negocio (Business Logic)
│   ├── BL_Empleado.cs              # Reglas de negocio de Empleados
│   ├── BL_Marcacion.cs             # Reglas de negocio de Marcaciones
│   └── BL_Usuario.cs               # Reglas de negocio de Usuarios
│
├── 📂 GUI/                         # Capa de Interfaz de Usuario (Windows Forms)
│   ├── Program.cs                  # Punto de entrada de la aplicación
│   ├── UIStyles.cs                 # Clase centralizada de estilos UX/UI
│   ├── MDIMenu.cs                  # Menú principal MDI
│   ├── frmLogin.cs                 # Formulario de autenticación
│   ├── frmGestionEmpleados.cs      # Gestión CRUD de Empleados
│   ├── frmGestionUsuario.cs        # Gestión CRUD de Usuarios
│   ├── frmMarcacion.cs             # Registro de marcaciones de asistencia
│   ├── frmReporteMarcaciones.cs    # Generación de reportes de asistencia
│   ├── frmViewRepMarcaciones.cs    # Visualización de reportes
│   ├── ReportMarcaciones.rdlc      # Plantilla de reporte de marcaciones
│   ├── repMarcacion.rdlc           # Plantilla alternativa de marcación
│   ├── repUsuarios.rdlc            # Plantilla de reporte de usuarios
│   └── App.config                  # Cadenas de conexión y configuración
│
├── 📂 Tests/                       # Capa de Pruebas Unitarias (NUnit + Moq)
│   ├── BL_UsuarioTests.cs          # 15 pruebas para BL_Usuario
│   ├── BL_EmpleadoTests.cs         # 15 pruebas para BL_Empleado
│   ├── E_UsuarioTests.cs           # 7 pruebas para E_Usuario
│   ├── E_EmpleadoTests.cs          # 7 pruebas para E_Empleado
│   └── E_MarcacionesTests.cs       # 6 pruebas para E_Marcaciones
│
├── 📄 Personal.sql                 # Script principal de base de datos
├── 📄 ScriptCompleto.sql           # Script completo consolidado
├── 📄 SPs_Empleados.sql            # Stored Procedures de Empleados
├── 📄 ARQUITECTURA_SISTEMA.md      # Documentación detallada de arquitectura
├── 📄 MEJORAS_UX_UI.md             # Documentación de mejoras de interfaz
└── 📄 SisPersonal.sln              # Solución de Visual Studio
```

---

## 🧩 Módulos del Sistema

### 🔐 1. Autenticación (`frmLogin`)
- Login con usuario y contraseña
- Validación de credenciales en capa de negocio (`BL_Usuario`)
- Control de perfiles de acceso (Administrador / Usuario estándar)
- Criptografía con BouncyCastle para protección de datos

### 👥 2. Gestión de Empleados (`frmGestionEmpleados`)
| Operación | Stored Procedure |
|---|---|
| Listar todos | `spListarEmpleados` |
| Insertar nuevo | `spInsertarEmpleado` |
| Actualizar datos | `spActualizarEmpleado` |
| Eliminar registro | `spEliminarEmpleado` |
| Buscar empleado | `spBuscarEmpleado` |

**Campos administrados**: ID, Apellido Paterno, Apellido Materno, Nombres, DNI, Dirección, Foto (imagen binaria), Estado, Salario Básico/Hora, Salario Horas Extra/Hora.

### 👤 3. Gestión de Usuarios (`frmGestionUsuario`)
- Alta, modificación, baja y consulta de usuarios del sistema
- Asignación de perfiles y estados
- Reporte de usuarios en formato `.rdlc`

### ⏱️ 4. Marcaciones de Asistencia (`frmMarcacion`)
- Registro de hora de ingreso
- Control de inicio/fin de refrigerio
- Registro de hora de salida
- Cálculo automático de horas trabajadas y horas de refrigerio
- Soporte para observaciones y mensajes por marcación

### 📊 5. Reportes (`frmReporteMarcaciones`, `frmViewRepMarcaciones`)
- Reportes de asistencia por fecha y empleado
- Visualización embebida mediante **Microsoft ReportViewer**
- Exportación a **PDF** mediante iTextSharp
- Exportación a **Excel** (soporte integrado en ReportViewer)

---

## 📦 Entidades de Datos

### `E_Marcaciones` (Clase Base)
```csharp
string  Id_Marcacion
string  Id_Empleado
DateTime Fecha
string  H_Ingreso          // Hora de ingreso
string  HS_Refrigerio      // Hora de salida a refrigerio
string  HI_Refrigerio      // Hora de ingreso de refrigerio
string  H_Salida           // Hora de salida
string  TH_Refrigerio      // Total horas de refrigerio
string  TH_Trabajadas      // Total horas trabajadas
string  Observacion
string  Mensaje
```

### `E_Empleado` (hereda de `E_Marcaciones`)
```csharp
string  ID_Empleado
string  Ape_Paterno
string  Ape_Materno
string  Nombres
string  DNI                // 8 caracteres
string  Direccion
byte[]  Foto               // Imagen almacenada como varbinary(MAX)
bool    Estado
decimal SBasicoHora
decimal SHorasExtraHora
```

### `E_Usuario`
```csharp
int     IdUsuario
string  Usuario
string  Clave
int     Estado
string  Perfil
```

---

## 🗄️ Base de Datos

### Nombre de la Base de Datos
```
dbControlPersonal   (usado en CAD/Conexion.cs)
Control_Personal    (usado en GUI/App.config)
```

### Tablas Principales
| Tabla | Descripción |
|---|---|
| `Empleados` | Datos completos de empleados |
| `Marcaciones` | Registro de asistencia diaria |
| `Usuarios` | Cuentas de acceso al sistema |

### Stored Procedures de Empleados
| Nombre | Descripción |
|---|---|
| `spListarEmpleados` | Retorna todos los empleados |
| `spInsertarEmpleado` | Inserta un nuevo empleado |
| `spActualizarEmpleado` | Actualiza datos de un empleado |
| `spEliminarEmpleado` | Elimina un empleado por ID |
| `spBuscarEmpleado` | Busca por nombres, apellidos o DNI |

> 📄 El script completo de creación se encuentra en **`SPs_Empleados.sql`** y **`Personal.sql`**.

---

## ⚙️ Configuración e Instalación

### 1. Clonar / Descargar el Proyecto
```
d:\Sistemas\SisPersonal\
```

### 2. Configurar la Base de Datos

1. Abrir **SQL Server Management Studio**
2. Ejecutar el script de creación de base de datos:
   ```sql
   -- Ejecutar en orden:
   -- 1. Personal.sql  (estructura de tablas)
   -- 2. SPs_Empleados.sql  (procedimientos almacenados)
   ```
3. Confirmar que la base de datos `dbControlPersonal` fue creada

### 3. Configurar la Cadena de Conexión

Editar el archivo **`GUI/App.config`** con los datos de tu servidor SQL:

```xml
<connectionStrings>
  <add name="cnx"
    connectionString="Server=TU_SERVIDOR;
                      Initial Catalog=dbControlPersonal;
                      User ID=sa;
                      Password=TU_CONTRASEÑA;
                      Encrypt=False;
                      TrustServerCertificate=True"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

> ⚠️ También verificar la cadena interna en **`CAD/Conexion.cs`** si no usas App.config en esa capa.

### 4. Restaurar Paquetes NuGet

En Visual Studio, haz clic derecho en la solución → **Restore NuGet Packages**, o desde la consola:

```powershell
nuget restore SisPersonal.sln
```

### 5. Compilar y Ejecutar

1. Abrir `SisPersonal.sln` en **Visual Studio 2019/2022**
2. Seleccionar configuración **Debug** o **Release**
3. Presionar **F5** o **Ctrl+F5** para iniciar

---

## 🧪 Pruebas Unitarias

El proyecto incluye **50 pruebas unitarias** organizadas con NUnit y Moq:

| Clase de Prueba | Pruebas | Cobertura |
|---|---|---|
| `BL_UsuarioTests` | 15 | BL_Usuario — Login, CRUD |
| `BL_EmpleadoTests` | 15 | BL_Empleado — CRUD completo |
| `E_UsuarioTests` | 7 | Propiedades y validaciones |
| `E_EmpleadoTests` | 7 | Propiedades y validaciones |
| `E_MarcacionesTests` | 6 | Fechas y campos de tiempo |
| **Total** | **50** | **100% pasando ✅** |

### Ejecutar las Pruebas

Desde **Visual Studio**:
- Menú → `Test` → `Run All Tests`
- O abrir el **Test Explorer** (`Ctrl+E, T`)

Desde **consola**:
```powershell
dotnet test Tests/Tests.csproj
```

### Estrategia de Testing
- **Mocking** de la capa CAD con **Moq** para aislar la base de datos
- **Inyección de dependencias** en constructores de BL
- **TDD** como enfoque de desarrollo
- Tiempo de ejecución: < 2 segundos

---

## 🎨 Patrones de Diseño

| Patrón | Implementación |
|---|---|
| **Layered Architecture** | Separación en CE / CAD / BL / GUI |
| **Repository Pattern** | Clases `D_*` encapsulan el acceso a datos |
| **Service Layer** | Clases `BL_*` como servicios de aplicación |
| **Dependency Injection** | Constructores con parámetros en BL para mocking |
| **Interface Segregation** | `ID_Usuario`, `ID_Empleado`, `ID_Marcaciones` |
| **Entity Pattern** | Clases `E_*` como POCOs del dominio |

---

## ✅ Principios SOLID

| Principio | Aplicación |
|---|---|
| **S** — Single Responsibility | Cada clase tiene una única responsabilidad |
| **O** — Open/Closed | Herencia `E_Empleado : E_Marcaciones`; extensible sin modificar |
| **L** — Liskov Substitution | Los mocks sustituyen implementaciones reales en tests |
| **I** — Interface Segregation | Interfaces específicas por módulo (no monolíticas) |
| **D** — Dependency Inversion | BL depende de abstracciones (interfaces), no de implementaciones |

---

## 📦 Paquetes NuGet

| Paquete | Versión | Proyecto | Uso |
|---|---|---|---|
| `Microsoft.SqlServer.Types` | 160.1000.6 | GUI, CAD | Tipos SQL Server |
| `iTextSharp` | 5.5.13.4 | GUI | Exportación a PDF |
| `BouncyCastle.Cryptography` | 2.5.0 | GUI | Encriptación |
| `Microsoft.ReportingServices.ReportViewerControl.Winforms` | 150.1652.0 | GUI | Visualización de reportes |
| `NUnit` | 3.13.3 | Tests | Framework de pruebas |
| `NUnit3TestAdapter` | 4.5.0 | Tests | Integración Visual Studio |
| `Moq` | 4.20.69 | Tests | Mocking de dependencias |
| `Castle.Core` | 5.1.1 | Tests | Proxy generation (Moq dep.) |

---

## 🖼️ Capturas del Sistema

> Las imágenes de fondo y recursos visuales se encuentran en:
> - `Fondo.png` — Imagen de fondo principal
> - `MenuFondo.jpg` — Fondo del menú MDI
> - `logo_bc.jpg` — Logo del sistema
> - `GUI/imagenes/` — Recursos de iconos y controles

---

## 📚 Documentación Adicional

| Documento | Descripción |
|---|---|
| [`ARQUITECTURA_SISTEMA.md`](ARQUITECTURA_SISTEMA.md) | Documentación técnica completa de la arquitectura N-Tier |
| [`MEJORAS_UX_UI.md`](MEJORAS_UX_UI.md) | Guía de mejoras de interfaz y paleta de colores |
| [`SPs_Empleados.sql`](SPs_Empleados.sql) | Scripts SQL de procedimientos almacenados de Empleados |
| [`Personal.sql`](Personal.sql) | Script completo de estructura de base de datos |

---

## 👤 Autor y Versión

| Campo | Valor |
|---|---|
| **Sistema** | SisPersonal — Sistema de Control de Personal |
| **Versión** | 2.0 |
| **Framework** | .NET Framework 4.8 |
| **IDE** | Visual Studio 2022 |
| **Base de Datos** | SQL Server |
| **Total de pruebas** | 50 (100% exitosas) |
| **Última actualización** | Febrero 2026 |

---

> 💡 **Nota de seguridad**: Antes de desplegar en producción, asegúrese de cambiar las credenciales de base de datos del archivo `App.config` y de `CAD/Conexion.cs`, y no incluirlas en control de versiones (revisar `.gitignore`).
