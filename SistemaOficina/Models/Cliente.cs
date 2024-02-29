namespace SistemaOficina.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public Cliente(string nomecli, string cpfcli, string fonecli, string endcli, string numerocli, string bairrocli, string cidadecli, string estadocli, string cepcli, string emailcli)
        {
            
            Nomecli = nomecli;
            Cpfcli = cpfcli;
            Fonecli = fonecli;
            Endcli = endcli;
            Numerocli = numerocli;
            Bairrocli = bairrocli;
            Cidadecli = cidadecli;
            Estadocli = estadocli;
            Cepcli = cepcli;
            Emailcli = emailcli;
        }

        public int Idcli { get; set; }
        public string Nomecli { get; set; }
        public string Cpfcli { get; set; }
        public string Fonecli { get; set; }
        public string Endcli { get; set; }
        public string Numerocli { get; set; }
        public string Bairrocli { get; set; }
        public string Cidadecli { get; set; }
        public string Estadocli { get; set; }
        public string Cepcli { get; set; }
        public string Emailcli { get; set; }
    }
}