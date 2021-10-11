using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;

namespace Admin
{
    public partial class ManejoUsuariosForm : Form
    {
        private Usuario _usuarioActual = null;
        private List<Usuario> _usuarios;
        private bool _nuevoRegistro = false;

        public ManejoUsuariosForm()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _usuarioActual = new Usuario();            
            _nuevoRegistro = true;
            
            CargarUsuarioActual();

            panRegistro.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panRegistro.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _usuarioActual.Login = txtLogin.Text;
            _usuarioActual.Nombre = txtNombre.Text;
            _usuarioActual.Clave= txtClave.Text;

            _usuarioActual.Email = txtMail.Text;

            _usuarioActual.FechaNacimiento = dtpFechaNacimiento.Value ;


            try
            {
                // guardar datos
                if (_nuevoRegistro)
                    Persistence.UsuariosRepository.Add(_usuarioActual);
                else
                    Persistence.UsuariosRepository.Update(_usuarioActual);

                CargarLista();

                panRegistro.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuario();
        }

        private void EditarUsuario()
        {
            if (listUsuarios.SelectedItem != null)
            {
                _usuarioActual = listUsuarios.SelectedItem as Usuario;
                _nuevoRegistro = false;

                CargarUsuarioActual();
                panRegistro.Visible = true;
            }
        }

        private void CargarUsuarioActual()
        {
            txtLogin.Text = _usuarioActual.Login;
            txtNombre.Text = _usuarioActual.Nombre;
            txtClave.Text = _usuarioActual.Clave;
            txtMail.Text = _usuarioActual.Email;
            dtpFechaNacimiento.Value = _usuarioActual.FechaNacimiento;

            txtLogin.Enabled = _nuevoRegistro;
        }

        private void ManejoUsuariosForm_Load(object sender, EventArgs e)
        {
            _usuarios = Persistence.UsuariosRepository.List();
            CargarLista();
        }

        private void CargarLista()
        {
            listUsuarios.Items.Clear();
            foreach (var usuario in _usuarios)
            {
                listUsuarios.Items.Add(usuario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listUsuarios.SelectedItem != null)
            {
                _usuarioActual = listUsuarios.SelectedItem as Usuario;

                Persistence.UsuariosRepository.Delete(_usuarioActual);
                CargarLista();
                MessageBox.Show("El usuario ha sido eliminado");
            }
        }

        private void listUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditarUsuario();
        }
    }
}
