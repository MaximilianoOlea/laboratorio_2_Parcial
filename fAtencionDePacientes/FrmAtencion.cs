using Entidades;
using System.Windows.Forms;

namespace fAtencionDePacientes
{
    public partial class FrmAtencion : Form
    {
        public FrmAtencion()
        {

            InitializeComponent();
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            lstMedicos.Items.Add(new PersonalMedico("Gustavo", "Rivas", new DateTime(1999, 12, 12), false));
            lstMedicos.Items.Add(new PersonalMedico("Lautaro", "Galarza", new DateTime(1951, 11, 12), true));
            lstPacientes.Items.Add(new Paciente("Mathias", "Bustamante", new DateTime(1998, 6, 16), "Tigre"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Ferrini", new DateTime(1989, 1, 21), "DF"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Rodriguez", new DateTime(1912, 12, 12), "LaBoca"));
            lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellin"));
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItem is null || lstPacientes.SelectedItem is null)
            {
                MessageBox.Show("Debe seleccionar un Médico y un Paciente para poder continuar.",
                                "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lstMedicos.SelectedItem is PersonalMedico m && lstPacientes.SelectedItem is Paciente p)
                {
                    Consulta c = m + p;
                    p.Diagnostico = "Paciente Curado";
                    MessageBox.Show(c.ToString(),"Atención finalizada");
                    rtbInfoMedico.Text = m.FichaPersonal(m) + m.FichaPersonal(p);
                }
                lstMedicos.SelectedIndex = -1;
                lstPacientes.SelectedIndex = -1;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lstMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItem is PersonalMedico m)
            {
                rtbInfoMedico.Text = m.FichaPersonal(m);

            }
        }
    }
}