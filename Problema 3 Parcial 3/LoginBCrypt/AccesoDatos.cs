using System.Text.Json;
using MySqlConnector;

namespace LoginBCrypt
{
    internal sealed class AccesoDatos
    {
        private string CrearCadena()
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "conexion.json");
            var config = JsonSerializer.Deserialize<Configuracion>(File.ReadAllText(ruta))
                ?? throw new InvalidOperationException();
            return new MySqlConnectionStringBuilder
            {
                Server = config.Servidor,
                Port = config.Puerto,
                UserID = config.Usuario,
                Password = config.Contrasena,
                Database = "login_bcrypt",
                ConnectionTimeout = 10
            }.ConnectionString;
        }

        public async Task PrepararUsuarioAsync()
        {
            using var conexion = new MySqlConnection(CrearCadena());
            await conexion.OpenAsync();
            using var consulta = new MySqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario", conexion);
            consulta.Parameters.AddWithValue("@usuario", "cristell");
            if (Convert.ToInt64(await consulta.ExecuteScalarAsync()) > 0)
            {
                return;
            }
            string hash = await Task.Run(() => BCrypt.Net.BCrypt.HashPassword("Cristell123*", workFactor: 12));
            using var comando = new MySqlCommand("INSERT INTO Usuarios (Nombre, Usuario, PasswordHash) VALUES (@nombre, @usuario, @hash)", conexion);
            comando.Parameters.AddWithValue("@nombre", "Cristell");
            comando.Parameters.AddWithValue("@usuario", "cristell");
            comando.Parameters.AddWithValue("@hash", hash);
            await comando.ExecuteNonQueryAsync();
        }

        public async Task<string?> AutenticarAsync(string usuario, string contrasena)
        {
            using var conexion = new MySqlConnection(CrearCadena());
            await conexion.OpenAsync();
            int? id = null;
            string? nombre = null;
            string? hash = null;
            using (var consulta = new MySqlCommand("SELECT IdUsuario, Nombre, PasswordHash FROM Usuarios WHERE Usuario = @usuario LIMIT 1", conexion))
            {
                consulta.Parameters.AddWithValue("@usuario", usuario);
                using var lector = await consulta.ExecuteReaderAsync();
                if (await lector.ReadAsync())
                {
                    id = lector.GetInt32(0);
                    nombre = lector.GetString(1);
                    hash = lector.GetString(2);
                }
            }
            bool exitoso = hash != null && await Task.Run(() => BCrypt.Net.BCrypt.Verify(contrasena, hash));
            using var intento = new MySqlCommand("INSERT INTO IntentosAcceso (IdUsuario, UsuarioIngresado, FechaHora, Exitoso) VALUES (@id, @usuario, NOW(), @exitoso)", conexion);
            intento.Parameters.AddWithValue("@id", (object?)id ?? DBNull.Value);
            intento.Parameters.AddWithValue("@usuario", usuario);
            intento.Parameters.AddWithValue("@exitoso", exitoso);
            await intento.ExecuteNonQueryAsync();
            return exitoso ? nombre : null;
        }
    }

    internal sealed class Configuracion
    {
        public string Servidor { get; set; } = "localhost";
        public uint Puerto { get; set; } = 3306;
        public string Usuario { get; set; } = "root";
        public string Contrasena { get; set; } = "";
    }
}
