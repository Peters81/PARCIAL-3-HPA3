using MySqlConnector;

namespace LoginBCrypt
{
    public partial class Form1 : Form
    {
        private readonly AccesoDatos datos = new AccesoDatos();

        public Form1()
        {
            InitializeComponent();
            txtContrasena.UseSystemPasswordChar = true;
            txtUsuario.MaxLength = 100;
            txtContrasena.MaxLength = 72;
            txtUsuario.TabIndex = 0;
            txtContrasena.TabIndex = 1;
            btnIniciarSesion.TabIndex = 2;
            btnSalir.TabIndex = 3;
            AcceptButton = btnIniciarSesion;
            StartPosition = FormStartPosition.CenterScreen;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            btnSalir.Click += btnSalir_Click;
        }

        private async void btnIniciarSesion_Click(object? sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Ingresa el usuario y la contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (System.Text.Encoding.UTF8.GetByteCount(contrasena) > 72)
            {
                MessageBox.Show("La contraseña supera el límite de 72 bytes.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnIniciarSesion.Enabled = false;
            try
            {
                await datos.PrepararUsuarioAsync();
                string? nombre = await datos.AutenticarAsync(usuario, contrasena);
                txtContrasena.Clear();
                if (nombre != null)
                {
                    MessageBox.Show($"Bienvenido/a, {nombre}.", "Acceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso rechazado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtContrasena.Focus();
            }
            catch (MySqlException)
            {
                MessageBox.Show("No se pudo completar el acceso en MySQL. Revisa que el servidor esté iniciado, los datos de conexion.json y los permisos del usuario. La base login_bcrypt y sus tablas deben estar creadas previamente con el SQL.", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo completar el acceso. Revisa conexion.json y que PasswordHash contenga un hash BCrypt válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIniciarSesion.Enabled = true;
            }
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
