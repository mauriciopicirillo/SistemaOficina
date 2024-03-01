namespace SistemaOficina.Models
{
    public class User
    {
        public User()
        { 
        }

        public User(int iduser, string nome, string usuario, string senha, string perfil)
        {
            IdUser = iduser;
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            Perfil = perfil;
        }

        public int IdUser { get; set; }
        public string Nome { get; private set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
