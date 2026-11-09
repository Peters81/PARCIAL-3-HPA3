namespace LoginBCrypt
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIniciarSesion = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnIniciarSesion);
            panel1.Controls.Add(txtContrasena);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(lblContrasena);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(214, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 426);
            panel1.TabIndex = 0;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(124, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(97, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Stencil", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(82, 123);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 27);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Inicio de sesión";
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(26, 164);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(76, 18);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(26, 233);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(106, 18);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "\tContraseña:";
            txtUsuario.BackColor = Color.LightSkyBlue;
            txtUsuario.Location = new Point(26, 185);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(269, 27);
            txtUsuario.TabIndex = 4;
            txtContrasena.BackColor = Color.LightSkyBlue;
            txtContrasena.Location = new Point(26, 269);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(269, 27);
            txtContrasena.TabIndex = 5;
            btnIniciarSesion.BackColor = Color.AliceBlue;
            btnIniciarSesion.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIniciarSesion.ForeColor = SystemColors.ActiveCaptionText;
            btnIniciarSesion.Location = new Point(26, 351);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(132, 29);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnSalir.BackColor = Color.AliceBlue;
            btnSalir.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(201, 351);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "\tSalir";
            btnSalir.UseVisualStyleBackColor = false;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }


        private Panel panel1;
        private Label lblTitulo;
        private PictureBox pictureBox1;
        private Button btnSalir;
        private Button btnIniciarSesion;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private Label lblUsuario;
    }
}
