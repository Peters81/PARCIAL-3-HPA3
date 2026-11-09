# Parcial #3 Práctico - Login con BCrypt

## Información del parcial

| Dato | Información |
|---|---|
| Universidad | Universidad Tecnológica de Panamá |
| Facultad | Facultad de Ingeniería de Sistemas Computacionales |
| Curso | Herramientas de la Programación Aplicada III (.NET) |
| Evaluación | Parcial #3 - Problema 3 |
| Estudiante | Cristell Peters |
| Grupo | 1IL133 |
| Docente | Ing. Irina Fong |
| Año | 2026 |

## Objetivos

🩷 Desarrollar un inicio de sesión en C# Windows Forms conectado a MySQL.

🩷 Utilizar BCrypt.Net-Next para generar y verificar hashes de contraseñas.

🩷 Registrar los intentos de acceso exitosos y fallidos con el usuario y la fecha.

🩷 Mostrar el nombre del usuario cuando las credenciales sean correctas.

## Contenido del parcial

En el problema 3 se desarrolló un programa de inicio de sesión con **C# Windows Forms**, **MySQL** y la biblioteca **BCrypt.Net-Next**. El usuario escribe sus credenciales en el formulario y el programa consulta la cuenta en la base de datos para verificar su contraseña.

La contraseña se almacena como un hash. Durante el acceso se utiliza `BCrypt.Verify()` para comprobar si el texto ingresado corresponde al hash guardado. También se registra el resultado de cada intento de autenticación para su consulta posterior.

## Diseño de la aplicación

Se utilizó un formulario con fondo azul claro, un panel central, una imagen, el título de inicio de sesión y los campos de usuario y contraseña. En la parte inferior están los botones **Iniciar sesión** y **Salir**.

El diseño se conserva en `Form1.Designer.cs` y sus recursos en `Form1.resx`, por lo que puede abrirse desde el diseñador de Visual Studio.

![Formulario de inicio de sesión](docs/capturas/login.png)

## Organización del proyecto

| Archivo | Función |
|---|---|
| `Program.cs` | Inicia la aplicación y abre el formulario. |
| `Form1.cs` | Recibe las credenciales, valida los campos y muestra el resultado. |
| `Form1.Designer.cs` | Contiene los controles y la distribución del formulario. |
| `Form1.resx` | Guarda los recursos del formulario. |
| `AccesoDatos.cs` | Conecta con MySQL, prepara el usuario de prueba, verifica la contraseña y registra los intentos. |
| `conexion.json` | Contiene los datos de conexión a MySQL. |
| `BaseDatos/backup_login_bcrypt.sql` | Crea la base, las tablas y el usuario inicial con su hash. |
| `BaseDatos/consultas.sql` | Consulta los usuarios y los intentos de acceso. |

## Generación del hash con BCrypt

En `AccesoDatos.cs`, el método `PrepararUsuarioAsync()` comprueba si existe el usuario de prueba `cristell`. Si no existe, genera el hash de su contraseña mediante:

```csharp
string hash = await Task.Run(() => BCrypt.Net.BCrypt.HashPassword("Cristell123*", workFactor: 12));
```

Después guarda el nombre, el usuario y el hash en la tabla `Usuarios`. Si la cuenta ya fue creada con el SQL, utiliza el registro existente y no modifica su contraseña.

El campo `PasswordHash` almacena el resultado de BCrypt, en lugar de la contraseña original.

![Usuario y hash almacenado en MySQL](docs/capturas/usuario_hash.png)

## Verificación de la contraseña

El método `AutenticarAsync()` busca el usuario mediante una consulta parametrizada y recupera su nombre y hash. Si encuentra la cuenta, comprueba la contraseña con:

```csharp
bool exitoso = hash != null && await Task.Run(() => BCrypt.Net.BCrypt.Verify(contrasena, hash));
```

El resultado permite aceptar o rechazar el acceso. El programa no necesita recuperar la contraseña original desde el hash.

## Base de datos MySQL

La base de datos se llama **`login_bcrypt`** y contiene dos tablas:

| Tabla | Campos | Uso |
|---|---|---|
| `Usuarios` | `IdUsuario`, `Nombre`, `Usuario`, `PasswordHash` | Guarda la cuenta y el hash de su contraseña. |
| `IntentosAcceso` | `IdIntento`, `IdUsuario`, `UsuarioIngresado`, `FechaHora`, `Exitoso` | Guarda los intentos de autenticación y sus resultados. |

La base y las tablas se crean ejecutando el SQL en **MySQL Workbench**. El código C# se conecta a esa estructura para consultar e insertar registros.

Cuando el usuario ingresado no existe, el intento conserva ese texto en `UsuarioIngresado` y registra `IdUsuario` como `NULL`.

![Tablas de la base de datos](docs/capturas/base_datos.png)

## Funcionalidades principales

### 🩷 Inicio de sesión exitoso

Al presionar **Iniciar sesión**, se leen los campos y se solicita la autenticación. Si las credenciales son correctas, se registra el acceso y aparece un mensaje con el nombre obtenido de la base de datos, por ejemplo: **Bienvenido/a, Cristell.**

![Acceso exitoso con el nombre del usuario](docs/capturas/acceso_exitoso.png)

### 🩷 Acceso rechazado

Si la contraseña es incorrecta o el usuario no existe, se registra un intento fallido y se muestra el mensaje **Usuario o contraseña incorrectos.**

![Mensaje de acceso rechazado](docs/capturas/acceso_fallido.png)

### 🩷 Registro de intentos

Cada intento de autenticación guarda el usuario ingresado, la fecha y hora, y el resultado. El campo `Exitoso` utiliza `1` para un acceso correcto y `0` para uno fallido.

Los registros se pueden consultar desde Workbench mediante `BaseDatos/consultas.sql`.

![Intentos exitosos y fallidos registrados](docs/capturas/intentos_acceso.png)

### 🩷 Validación de campos

Si falta el usuario o la contraseña, se solicita completar ambos datos antes de consultar las credenciales. El campo de contraseña oculta los caracteres escritos y el botón **Salir** cierra el formulario.

![Validación de campos vacíos](docs/capturas/campos_vacios.png)

## Conexión entre C# y MySQL

Se utiliza **MySqlConnector** para acceder a la base de datos. El método `CrearCadena()` obtiene los datos desde `conexion.json`.

La contraseña del usuario de MySQL es independiente de la contraseña que se escribe en el formulario de acceso.

## Instalación y ejecución

1. Tener MySQL, Visual Studio con desarrollo de escritorio .NET y el SDK de .NET 10.
2. Iniciar el servidor MySQL.
3. Ejecutar `BaseDatos/backup_login_bcrypt.sql` en Workbench si la base todavía no está creada. Si ya se ejecutó correctamente, continuar al siguiente paso.
4. Configurar `LoginBCrypt/conexion.json` con el servidor, puerto, usuario y contraseña de MySQL correspondientes a la computadora.
5. Abrir `LoginBCrypt.slnx` en Visual Studio.
6. Restaurar los paquetes NuGet y ejecutar con **Ctrl + F5**.

Cuenta de prueba:

| Usuario | Contraseña |
|---|---|
| `cristell` | `Cristell123*` |

Antes de publicar el proyecto, retirar la contraseña personal de MySQL de `conexion.json`.

## Comprobación del funcionamiento

| Prueba | Resultado esperado |
|---|---|
| Ingresar `cristell` con `Cristell123*` | Muestra el nombre y registra un acceso exitoso. |
| Ingresar `cristell` con otra contraseña | Rechaza el acceso y registra un intento fallido. |
| Ingresar un usuario inexistente | Rechaza el acceso y conserva el usuario ingresado en el registro. |
| Dejar un campo vacío | Solicita completar los datos. |
| Consultar `IntentosAcceso` | Muestra usuario, fecha, hora y resultado de los intentos realizados. |

## Backup de la base de datos

Se incluye `BaseDatos/backup_login_bcrypt.sql` con la estructura y el usuario inicial. Después de realizar las pruebas, se debe exportar desde Workbench la base `login_bcrypt` con **estructura y datos**, para incluir en la entrega los intentos registrados durante la ejecución.

El repositorio debe contener el código del proyecto y el backup solicitado en el enunciado.

## Controles utilizados

| Control | Uso |
|---|---|
| `Form` | Ventana de inicio de sesión. |
| `Panel` | Agrupa los controles del login. |
| `PictureBox` | Muestra la imagen del formulario. |
| `Label` | Presenta el título y los nombres de los campos. |
| `TextBox` | Recibe usuario y contraseña. |
| `Button` | Permite iniciar sesión o salir. |
| `MessageBox` | Informa el resultado del acceso y las validaciones. |

## Herramientas utilizadas

| Herramienta | Uso |
|---|---|
| C# y .NET 10 | Desarrollo del programa. |
| Windows Forms | Diseño de la interfaz. |
| Visual Studio | Edición del código y del formulario. |
| MySQL y MySQL Workbench | Almacenamiento y consulta de datos. |
| BCrypt.Net-Next 4.2.0 | Generación y verificación de hashes. |
| MySqlConnector 2.6.2 | Comunicación entre C# y MySQL. |
| GitHub | Entrega del código y documentación. |

## Resultado del trabajo

El proyecto reúne el inicio de sesión, el manejo de contraseñas con BCrypt y el registro de accesos en MySQL. Se trabajó con la consulta de usuarios, la verificación del hash y el almacenamiento de intentos exitosos y fallidos. El formulario informa el resultado y muestra el nombre cuando el acceso es correcto.
