using System.Drawing;
using System.Windows.Forms;

namespace SistemaTurnos
{
    public class FormGrafico : Form
    {
        private PictureBox picGrafico;
        private Label lblTitulo;

        public FormGrafico(string imagePath)
        {
            this.Text = "Cola de Pacientes en Espera";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "🏥 Pacientes en Espera - Vista Gráfica";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.SteelBlue;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Size = new Size(600, 30);
            this.Controls.Add(lblTitulo);

            // PictureBox grande
            picGrafico = new PictureBox();
            picGrafico.Location = new Point(20, 60);
            picGrafico.Size = new Size(840, 480);
            picGrafico.SizeMode = PictureBoxSizeMode.Zoom;
            picGrafico.BackColor = Color.White;
            picGrafico.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(picGrafico);

            // Cargar imagen
            if (File.Exists(imagePath))
            {
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    picGrafico.Image = Image.FromStream(stream);
                }
            }
        }
    }
}