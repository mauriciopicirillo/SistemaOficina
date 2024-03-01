namespace SistemaOficina.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public Cliente(string nome, string cpf, string fone, string end, string numero, string bairro, string cidade, string estado, string cep, string email)
        {
            
            Nome = nome;
            Cpf = cpf;
            Fone = fone;
            End = end;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Email = email;
        }

        public int Idcli { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fone { get; set; }
        public string End { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
    }
}