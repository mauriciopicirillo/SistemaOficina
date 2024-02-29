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
            string login = txtUsuario.Text;
            string senha = txtSenha.Text;

            UserController usersController = new UserController(new DataContext()); // Substitua pelo seu DataContext real

            if (usersController.VerificarLoginSenha(login, senha))
            {
                // Login bem-sucedido, faça o que for necessário
                MessageBox.Show("Login bem-sucedido!");

                TelaPrincipal principal = new TelaPrincipal();
                principal.Show();

                

                this.Hide();
                

            }
            else
            {
                // Login falhou, você pode exibir uma mensagem de erro
                MessageBox.Show("Login falhou. Verifique seu nome de usuário e senha.");
            }

        }
    }
}
