using SistemaOficina.Data;
using System.Linq;

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
                // Consulta o banco de dados para encontrar um usuário com o login e senha correspondentes
                var login = dbContext.TbUsuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);

                // Se encontrar o usuário, retorna verdadeiro. Caso contrário, retorna falso.
                return login != null;
            }
            catch (Exception ex)
            {
                // Lide com exceções, log, ou retorne falso em caso de erro
                Console.WriteLine($"Erro ao verificar login e senha: {ex.Message}");
                return false;
            }
        }
    }
}