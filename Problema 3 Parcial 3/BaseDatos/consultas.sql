USE login_bcrypt;
SELECT IdUsuario, Nombre, Usuario, PasswordHash FROM Usuarios;
SELECT IdIntento, UsuarioIngresado, FechaHora, Exitoso FROM IntentosAcceso ORDER BY IdIntento DESC;
