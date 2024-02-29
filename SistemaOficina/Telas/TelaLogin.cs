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
                // Login bem-sucedido, fa�a o que for necess�rio
                MessageBox.Show("Login bem-sucedido!");

                TelaPrincipal principal = new TelaPrincipal();
                principal.Show();

                

                this.Hide();
                

            }
            else
            {
                // Login falhou, voc� pode exibir uma mensagem de erro
                MessageBox.Show("Login falhou. Verifique seu nome de usu�rio e senha.");
            }

        }
    }
}
