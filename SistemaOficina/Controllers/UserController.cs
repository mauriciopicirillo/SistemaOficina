using SistemaOficina.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaOficina.Controllers
{
    public class UserController
    {
        private DataContext dbContext;

        // Certifique-se de ter a instância do seu DataContext aqui ao criar UserController
        public UserController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool VerificarLoginSenha(string usuario, string senha)
        {
            try
            {
                // Consulta o banco de dados para encontrar um usuário com o login correspondente
                var user = dbContext.TbUsuarios.FirstOrDefault(u => u.Usuario == usuario);

                // Verifica se o usuário foi encontrado e se a senha corresponde
                if (user != null && user.Senha == senha)
                {
                    // Se encontrar o usuário e a senha corresponder, retorna verdadeiro
                    return true;
                }
                else
                {
                    // Se o usuário não for encontrado ou a senha não corresponder, retorna falso
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Lide com exceções, log, ou retorne falso em caso de erro
                MessageBox.Show($"Erro ao verificar login e senha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}