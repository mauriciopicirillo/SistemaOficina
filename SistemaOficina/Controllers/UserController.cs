using SistemaOficina.Data;

namespace SistemaOficina.Controllers
{
    public class UserController
    {
        private DataContext dbContext; // Certifique-se de ter a instância do seu DataContext aqui

        public UserController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool VerificarLoginSenha(string login, string senha)
        {
            // Consulta o banco de dados para encontrar um usuário com o login e senha correspondentes
            var usuario = dbContext.Tbusuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);

            // Se encontrar o usuário, retorna verdadeiro. Caso contrário, retorna falso.
            return usuario != null;
        }

    }
}
