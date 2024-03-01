using SistemaOficina.Controllers;
using SistemaOficina.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOficina.Telas
{
    public partial class TelaPrincipal : Form
    {
        private ClienteController clienteController;

        public TelaPrincipal()
        {
            InitializeComponent();

            DataContext dataContext = new DataContext();  
            clienteController = new ClienteController(dataContext);
        }

        private void tabOrcamentos_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string telefone = txtTelefone.Text;
            string endereco = txtEndereco.Text;
            string numero = txtNumero.Text;
            string bairro = txtBairro.Text;
            string cidade = txtCidade.Text;
            string estado = txtUf.Text;
            string cep = txtCep.Text;
            string email = txtEmail.Text;

            // Chama o método SalvarCliente do ClienteController
            string resultado = clienteController.SalvarCliente(nome, cpf, telefone, endereco,
                                                               numero, bairro, cidade, estado, cep, email);

            // Exibe o resultado em uma MessageBox ou de outra forma
            MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
