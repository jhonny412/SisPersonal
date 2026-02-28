# GUÍA DE IMPLEMENTACIÓN - MEJORAS DE SEGURIDAD EN AUTENTICACIÓN

## 📋 RESUMEN DE CAMBIOS IMPLEMENTADOS

Se han implementado las siguientes mejoras de seguridad críticas:

### 1. ✅ Hash Seguro de Contraseñas (PBKDF2 + Salt)
- **Archivo:** `BL/SecurityHelper.cs`
- **Función:** `SecurityHelper.HashContraseña()` y `SecurityHelper.VerificarContraseña()`
- **Algoritmo:** PBKDF2-SHA256 con 10,000 iteraciones
- **Salt:** 16 bytes generados aleatoriamente
- **Beneficio:** Las contraseñas nunca se almacenan en texto plano

### 2. ✅ Rate Limiting - Prevención de Ataques de Fuerza Bruta
- **Archivo:** `BL/RateLimiter.cs`
- **Límite:** Máximo 5 intentos fallidos por usuario
- **Bloqueo:** 15 minutos después de exceder el límite
- **Reseteo:** El contador se resetea tras un login exitoso
- **Beneficio:** Protege contra ataques de fuerza bruta

### 3. ✅ Logging de Auditoría
- **Archivo:** `BL/AuthenticationLogger.cs`
- **Registro:** Todos los intentos de login (exitosos y fallidos)
- **Ubicación:** `%APPDATA%\SisPersonal\Logs\auth_YYYY-MM-DD.log`
- **Información:** Timestamp, usuario, tipo de evento, detalles
- **Beneficio:** Auditoría completa de intentos de acceso

### 4. ✅ Encriptación en Tránsito
- **Archivo:** `CAD/Conexion.cs` y `GUI/App.config`
- **Cambio:** `Encrypt=False` → `Encrypt=True`
- **Beneficio:** Las credenciales se encriptan en la transmisión a SQL Server

### 5. ✅ Credenciales Fuera del Código
- **Archivo:** `CAD/Conexion.cs`
- **Método:** Lee de variables de entorno o App.config (no hardcoded)
- **Variables de Entorno:**
  - `SQL_SERVER`
  - `SQL_DATABASE`
  - `SQL_USER`
  - `SQL_PASSWORD`
- **Beneficio:** Las credenciales no están expuestas en el código

### 6. ✅ Validación de Complejidad
- **Archivo:** `BL/SecurityHelper.cs`
- **Función:** `SecurityHelper.ValidarComplejidadContraseña()`
- **Requisitos:**
  - Mínimo 8 caracteres
  - Al menos una mayúscula
  - Al menos una minúscula
  - Al menos un número
  - Al menos un carácter especial
- **Modo Leniente:** `ValidarComplejidadBasica()` solo requiere 6 caracteres (para login)

---

## 🚀 PASOS DE IMPLEMENTACIÓN

### PASO 1: Aumentar el Tamaño de la Columna de Contraseña

Las contraseñas hasheadas son más largas. Ejecute este script SQL:

```sql
-- En SQL Server, ejecute esto en la BD dbControlPersonal
ALTER TABLE Usuarios 
ALTER COLUMN Clave VARCHAR(200) NOT NULL;
```

**Razón:** Los hashes PBKDF2 en Base64 ocupan ~68-80 caracteres, no 25.

---

### PASO 2: Migrar Contraseñas Existentes (UNA SOLA VEZ)

Ejecute esto en su aplicación (una sola vez):

```csharp
// En Program.cs o en un formulario de administración
CAD.PasswordMigration migration = new CAD.PasswordMigration();

// Verificar estado antes de migrar
int contrasenasPlanas = migration.VerificarEstadoMigracion();
Console.WriteLine($"Contraseñas en texto plano encontradas: {contrasenasPlanas}");

// Si hay contraseñas en texto plano, migrar
if (contrasenasPlanas > 0)
{
    migration.MigrarContraseñasAHash();
    Console.WriteLine("Migración completada");
}
```

**IMPORTANTE:** Ejecute esto solo una vez. Después que todas las contraseñas estén hasheadas, no vuelva a ejecutarlo.

---

### PASO 3: Configurar Variables de Entorno (Recomendado)

Para mayor seguridad, configure variables de entorno en su máquina:

#### En Windows (Cmd como Administrador):
```bash
setx SQL_SERVER "tu_servidor"
setx SQL_DATABASE "dbControlPersonal"
setx SQL_USER "usuario_db"
setx SQL_PASSWORD "tu_contraseña"
```

#### En Windows (PowerShell como Administrador):
```powershell
[Environment]::SetEnvironmentVariable("SQL_SERVER", "tu_servidor", [EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("SQL_DATABASE", "dbControlPersonal", [EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("SQL_USER", "usuario_db", [EnvironmentVariableTarget]::User)
[Environment]::SetEnvironmentVariable("SQL_PASSWORD", "tu_contraseña", [EnvironmentVariableTarget]::User)
```

---

### PASO 4: Compilar y Probar

```bash
# Limpiar solución
dotnet clean

# Compilar
dotnet build

# Ejecutar pruebas
dotnet test
```

---

## 🧪 PRUEBAS DE SEGURIDAD

### Prueba 1: Verificar Hash de Contraseña

```csharp
// Generar hash
string hash = BL.SecurityHelper.HashContraseña("MiContraseña123!");

// Verificar que es correcto
bool esValido = BL.SecurityHelper.VerificarContraseña("MiContraseña123!", hash);
Console.WriteLine(esValido); // True

// Verificar que rechaza contraseña incorrecta
bool esInvalido = BL.SecurityHelper.VerificarContraseña("ContraseñaIncorrecta", hash);
Console.WriteLine(esInvalido); // False
```

### Prueba 2: Verificar Rate Limiting

```csharp
// Simular 5 intentos fallidos
for (int i = 1; i <= 5; i++)
{
    BL.RateLimiter.RegistrarIntentoFallido("testuser");
}

// Intentar acceso
var (bloqueado, minutos) = BL.RateLimiter.VerificarBloqueo("testuser");
Console.WriteLine($"Bloqueado: {bloqueado}, Minutos restantes: {minutos}");

// Resetear tras login exitoso
BL.RateLimiter.ResetearIntentos("testuser");
```

### Prueba 3: Verificar Logging

```csharp
// Registrar eventos
BL.AuthenticationLogger.RegistrarLoginExitoso("admin", "Administrador");
BL.AuthenticationLogger.RegistrarLoginFallido("admin", "Contraseña incorrecta");

// Leer log del día
string log = BL.AuthenticationLogger.ObtenerLogDelDia();
Console.WriteLine(log);

// Ubicación: C:\Users\[Usuario]\AppData\Roaming\SisPersonal\Logs\
```

### Prueba 4: Validar Complejidad

```csharp
// Contraseña débil
var (valida, msg) = BL.SecurityHelper.ValidarComplejidadContraseña("123456");
Console.WriteLine(msg); // Muestra requisitos faltantes

// Contraseña fuerte
var (valida2, msg2) = BL.SecurityHelper.ValidarComplejidadContraseña("MiPass123!@#");
Console.WriteLine(msg2); // "Contraseña válida"
```

---

## ⚠️ CAMBIOS EN EL COMPORTAMIENTO

### Login

**ANTES:**
```
Usuario: admin
Contraseña: 123456 ✓ (aceptada tal cual)
```

**AHORA:**
```
Usuario: admin
Contraseña: 123456
↓
Verificación de hash en BD
↓
Protección contra rate limiting
↓
Registro en log de auditoría
```

### Mensajes de Error

**ANTES:**
- "Los datos de identificación son incorrectos"

**AHORA:**
- "Los datos de identificación son incorrectos" (si usuario no existe)
- "Usuario o contraseña incorrectos. Intento 1 de 5" (si contraseña incorrecta)
- "Cuenta bloqueada por demasiados intentos. Intente en 15 minutos." (si alcanzó límite)

---

## 📂 ARCHIVOS MODIFICADOS Y NUEVOS

### Nuevos Archivos:
- ✅ `BL/SecurityHelper.cs` - Hash y validación de contraseña
- ✅ `BL/RateLimiter.cs` - Control de intentos
- ✅ `BL/AuthenticationLogger.cs` - Auditoría
- ✅ `CAD/PasswordMigration.cs` - Migración de contraseñas

### Archivos Modificados:
- ✅ `CAD/D_Usuario.cs` - Actualizar comentarios
- ✅ `BL/BL_Usuario.cs` - Implementar login seguro
- ✅ `GUI/frmLogin.cs` - Integrar nuevas validaciones
- ✅ `CAD/Conexion.cs` - Usar variables de entorno y encriptación
- ✅ `GUI/App.config` - Actualizar connection strings

---

## 🔍 VERIFICACIÓN POST-IMPLEMENTACIÓN

### Checklist de Seguridad

- [ ] Las contraseñas se almacenan como hashes (no texto plano)
- [ ] Rate limiting activo (máximo 5 intentos)
- [ ] Logs de auditoría se crean en `%APPDATA%\SisPersonal\Logs\`
- [ ] Conexión a BD usa `Encrypt=True`
- [ ] Credenciales no están hardcoded en el código
- [ ] Validación de complejidad funciona
- [ ] Todas las pruebas unitarias pasan

### Comando de Verificación:

```bash
# Verificar que no hay credenciales en el código
git grep -i "password" --exclude-dir=.git | grep -i "sunat"

# Verificar que no hay Encrypt=False
git grep "Encrypt=False"
```

---

## 🚨 TROUBLESHOOTING

### Error: "La contraseña no se guarda correctamente"

**Causa:** Columna Clave es demasiado pequeña (CHAR(25))  
**Solución:** Ejecutar script SQL para aumentar tamaño a VARCHAR(200)

### Error: "Variable de entorno no encontrada"

**Causa:** Las variables de entorno no se configuraron  
**Solución:** Configurar manualmente o dejar valores por defecto en App.config

### Error: "El usuario está bloqueado"

**Causa:** Se alcanzó el límite de 5 intentos  
**Solución:** Esperar 15 minutos o reiniciar la aplicación (resetea en memoria)

---

## 📊 MEJORAS IMPLEMENTADAS RESUMEN

| Aspecto | Antes | Después | Nivel |
|---------|-------|---------|-------|
| Almacenamiento Contraseña | Texto plano | PBKDF2 Hash | 🔴 → ✅ |
| Encriptación en Tránsito | No | Sí (Encrypt=True) | 🔴 → ✅ |
| Rate Limiting | No | 5 intentos/15 min | 🔴 → ✅ |
| Auditoría | No | Logging completo | 🔴 → ✅ |
| Validación Contraseña | Básica | Complejidad + Hash | 🟡 → ✅ |
| Credenciales Código | Hardcoded | Env vars | 🔴 → ✅ |

---

## 📞 SOPORTE

Si tiene preguntas sobre la implementación, consulte:
1. Los comentarios en el código
2. Las pruebas unitarias en `BL_UsuarioTests.cs`
3. Los logs en `%APPDATA%\SisPersonal\Logs\`

---

**Última actualización:** 2026-02-25  
**Versión:** 1.0 - Mejoras de Seguridad Críticas
