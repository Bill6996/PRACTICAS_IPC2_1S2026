using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public partial class Form1 : Form
    {
        private ColaTurnos cola;
        private GeneradorGrafico generador;

        // Controles
        private TextBox txtNombre;
        private TextBox txtEdad;
        private ComboBox cmbEspecialidad;
        private Button btnAgregar;
        private Button btnAtender;
        private Button btnVerGrafico;
        private ListBox lstCola;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblEspecialidad;
        private Label lblCola;
        private Label lblTitulo;
        private Label lblInfo;
        private PictureBox picGrafico;

        public Form1()
        {
            cola = new ColaTurnos();
            generador = new GeneradorGrafico();
            InitializeComponent();
            InicializarUI();
        }

        private void InicializarUI()
        {
            this.Text = "Sistema de Turnos Médicos - USAC";
            this.Size = new Size(900, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = " Sistema de Turnos Médicos - USAC";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.SteelBlue;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Size = new Size(500, 35);
            this.Controls.Add(lblTitulo);

            // Label Nombre
            lblNombre = new Label();
            lblNombre.Text = "Nombre del Paciente:";
            lblNombre.Location = new Point(20, 70);
            lblNombre.Size = new Size(160, 20);
            lblNombre.Font = new Font("Segoe UI", 9);
            this.Controls.Add(lblNombre);

            // TextBox Nombre
            txtNombre = new TextBox();
            txtNombre.Location = new Point(190, 67);
            txtNombre.Size = new Size(180, 25);
            txtNombre.Font = new Font("Segoe UI", 9);
            this.Controls.Add(txtNombre);

            // Label Edad
            lblEdad = new Label();
            lblEdad.Text = "Edad:";
            lblEdad.Location = new Point(20, 105);
            lblEdad.Size = new Size(160, 20);
            lblEdad.Font = new Font("Segoe UI", 9);
            this.Controls.Add(lblEdad);

            // TextBox Edad
            txtEdad = new TextBox();
            txtEdad.Location = new Point(190, 102);
            txtEdad.Size = new Size(180, 25);
            txtEdad.Font = new Font("Segoe UI", 9);
            this.Controls.Add(txtEdad);

            // Label Especialidad
            lblEspecialidad = new Label();
            lblEspecialidad.Text = "Especialidad:";
            lblEspecialidad.Location = new Point(20, 140);
            lblEspecialidad.Size = new Size(160, 20);
            lblEspecialidad.Font = new Font("Segoe UI", 9);
            this.Controls.Add(lblEspecialidad);

            // ComboBox Especialidad
            cmbEspecialidad = new ComboBox();
            cmbEspecialidad.Location = new Point(190, 137);
            cmbEspecialidad.Size = new Size(180, 25);
            cmbEspecialidad.Font = new Font("Segoe UI", 9);
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.Items.AddRange(new string[]
            {
        "Medicina General",
        "Pediatría",
        "Ginecología",
        "Dermatología"
            });
            cmbEspecialidad.SelectedIndex = 0;
            this.Controls.Add(cmbEspecialidad);

            // Botón Agregar
            btnAgregar = new Button();
            btnAgregar.Text = " Agregar Turno";
            btnAgregar.Location = new Point(20, 180);
            btnAgregar.Size = new Size(170, 35);
            btnAgregar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAgregar.BackColor = Color.SteelBlue;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(btnAgregar);

            // Botón Atender
            btnAtender = new Button();
            btnAtender.Text = " Atender Siguiente";
            btnAtender.Location = new Point(200, 180);
            btnAtender.Size = new Size(170, 35);
            btnAtender.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAtender.BackColor = Color.SeaGreen;
            btnAtender.ForeColor = Color.White;
            btnAtender.FlatStyle = FlatStyle.Flat;
            btnAtender.Click += BtnAtender_Click;
            this.Controls.Add(btnAtender);

            // Botón Ver Gráfico
            btnVerGrafico = new Button();
            btnVerGrafico.Text = " Ver Gráfico";
            btnVerGrafico.Location = new Point(20, 225);
            btnVerGrafico.Size = new Size(170, 35);
            btnVerGrafico.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnVerGrafico.BackColor = Color.DarkOrange;
            btnVerGrafico.ForeColor = Color.White;
            btnVerGrafico.FlatStyle = FlatStyle.Flat;
            btnVerGrafico.Click += BtnVerGrafico_Click;
            this.Controls.Add(btnVerGrafico);

            // Botón Salir
            Button btnSalir = new Button();
            btnSalir.Text = " Salir";
            btnSalir.Location = new Point(200, 225);
            btnSalir.Size = new Size(170, 35);
            btnSalir.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnSalir.BackColor = Color.Crimson;
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Click += (s, e) => Application.Exit();
            this.Controls.Add(btnSalir);

            // Label Cola
            lblCola = new Label();
            lblCola.Text = "Pacientes en espera:";
            lblCola.Location = new Point(20, 275);
            lblCola.Size = new Size(200, 20);
            lblCola.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.Controls.Add(lblCola);

            // ListBox Cola
            lstCola = new ListBox();
            lstCola.Location = new Point(20, 300);
            lstCola.Size = new Size(840, 250);
            lstCola.Font = new Font("Segoe UI", 9);
            this.Controls.Add(lstCola);

            // Label Info
            lblInfo = new Label();
            lblInfo.Text = "Vista del Gráfico:";
            lblInfo.Location = new Point(400, 60);
            lblInfo.Size = new Size(200, 20);
            lblInfo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.Controls.Add(lblInfo);

            // PictureBox
            picGrafico = new PictureBox();
            picGrafico.Location = new Point(400, 85);
            picGrafico.Size = new Size(460, 185);
            picGrafico.BorderStyle = BorderStyle.FixedSingle;
            picGrafico.SizeMode = PictureBoxSizeMode.Zoom;
            picGrafico.BackColor = Color.White;
            this.Controls.Add(picGrafico);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string edadTexto = txtEdad.Text.Trim();
            string especialidad = cmbEspecialidad.SelectedItem.ToString();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor ingresa el nombre del paciente.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (char c in nombre)
                {
                    if (char.IsDigit(c))
                        throw new FormatException("El nombre no puede contener números.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(edadTexto, out int edad) || edad <= 0)
            {
                MessageBox.Show("Por favor ingresa una edad válida.", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cola.Encolar(nombre, edad, especialidad);
            ActualizarLista();
            ActualizarGrafico();

            txtNombre.Clear();
            txtEdad.Clear();
            cmbEspecialidad.SelectedIndex = 0;

            MessageBox.Show($"Turno agregado para {nombre}.\nEspera estimada: {cola.CalcularTiempoEsperaTotal() - cola.ObtenerTodos().Last().TiempoAtencion} minutos.", "Turno Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAtender_Click(object sender, EventArgs e)
        {
            if (cola.EstaVacia())
            {
                MessageBox.Show("No hay turnos pendientes.", "Cola Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nodo atendido = cola.Desencolar();
            ActualizarLista();
            ActualizarGrafico();

            MessageBox.Show($"Atendiendo a: {atendido.Nombre}\nEdad: {atendido.Edad}\nEspecialidad: {atendido.Especialidad}\nTiempo de atención: {atendido.TiempoAtencion} minutos.", "Paciente Atendido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVerGrafico_Click(object sender, EventArgs e)
        {
            try
            {
                string imgPath = generador.GenerarImagen(cola);
                FormGrafico formGrafico = new FormGrafico(imgPath);
                formGrafico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarLista()
        {
            lstCola.Items.Clear();
            List<Nodo> nodos = cola.ObtenerTodos();
            int tiempoAcumulado = 0;

            for (int i = 0; i < nodos.Count; i++)
            {
                Nodo n = nodos[i];
                int tiempoTotal = tiempoAcumulado + n.TiempoAtencion;
                lstCola.Items.Add($"#{i + 1} | {n.Nombre} | {n.Edad} años | {n.Especialidad} | Espera: {tiempoAcumulado} min | Total: {tiempoTotal} min");
                tiempoAcumulado += n.TiempoAtencion;
            }
        }

        private void ActualizarGrafico()
        {
            try
            {
                string imgPath = generador.GenerarImagen(cola);

                if (File.Exists(imgPath))
                {
                    // Cargar la imagen en memoria para liberar el archivo
                    using (var stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(stream);

                        // Liberar imagen anterior
                        if (picGrafico.Image != null)
                        {
                            picGrafico.Image.Dispose();
                            picGrafico.Image = null;
                        }

                        picGrafico.Image = img;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error al generar gráfico: " + ex.Message;
            }
        }
    }
}