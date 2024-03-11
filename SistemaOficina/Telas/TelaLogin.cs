using SistemaOficina.Controllers;
using SistemaOficina.Data;
using SistemaOficina.Telas;

namespace SistemaOficina
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            UserController usersController = new UserController(new DataContext());

            if (usersController.VerificarLoginSenha(usuario, senha))
            {
                

                TelaPrincipal principal = new TelaPrincipal();
                principal.Show();

                this.Hide(); // Fecha apenas a TelaLogin
            }
            else
            {
                // Login falhou, exibir uma mensagem de erro
                MessageBox.Show("Nome de usuário ou senha incorretos.", "Erro");
            }
        }
    }
}
