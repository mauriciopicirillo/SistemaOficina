namespace SistemaOficina.Models
{
    public class User
    {
        public User()
        { 
        }

        public User(int iduser, string usuario, string login, string senha, string perfil)
        {
            IdUser = iduser;
            Usuario = usuario;
            Login = login;
            Senha = senha;
            Perfil = perfil;
        }

        public int IdUser { get; set; }
        public string Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
