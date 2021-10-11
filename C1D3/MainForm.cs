using System;
using System.Windows.Forms;
using Admin;

namespace C1D3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Persistence.UsuariosRepository.LoadTestData();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            ManejoUsuariosForm form = new ManejoUsuariosForm();
            form.ShowDialog();
        }
    }
}
