using SistemaOficina.Controllers;
using SistemaOficina.Data;

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

            // Se a operação foi bem-sucedida, limpa os campos
            if (resultado.Contains("foi adicionado com sucesso"))
            {
                LimparCampos();
            }
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            txtIdCliente.Text = "";
            txtNome.Text = "";
            txtCpf.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
            txtCep.Text = "";
            txtEmail.Text = "";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            // Obtém o texto do campo txtPesquisa
            string cpfPesquisa = txtPesquisa.Text;

            // Chama o método do controlador para pesquisar e atualizar o dataGridView
            AtualizarDataGridViewPorCPF(cpfPesquisa);
        }

        private void AtualizarDataGridViewPorCPF(string cpf)
        {
            // Chama o método do controlador para pesquisar
            var resultados = clienteController.PesquisarPorCPF(cpf);

            // Antes de atribuir a origem de dados
            dtgClientes.AutoGenerateColumns = true;

            // Atualiza o dataGridView com os resultados da pesquisa
            dtgClientes.DataSource = resultados;
        }

        private void dtgClientes_SelectionChanged(object sender, EventArgs e)
        {
            PreencherCamposComDadosDaLinhaSelecionada();
        }

        // Método para preencher os campos com os dados da linha selecionada e desativar btnSave
        private void PreencherCamposComDadosDaLinhaSelecionada()
        {
            // Verifica se há pelo menos uma linha selecionada
            if (dtgClientes.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = dtgClientes.SelectedRows[0];

                // Preenche os campos de texto com os dados da linha selecionada
                txtIdCliente.Text = linhaSelecionada.Cells["Idcli"].Value.ToString();
                txtNome.Text = linhaSelecionada.Cells["Nome"].Value.ToString();
                txtCpf.Text = linhaSelecionada.Cells["Cpf"].Value.ToString();
                txtTelefone.Text = linhaSelecionada.Cells["Fone"].Value.ToString();
                txtEndereco.Text = linhaSelecionada.Cells["End"].Value.ToString();
                txtNumero.Text = linhaSelecionada.Cells["Numero"].Value.ToString();
                txtBairro.Text = linhaSelecionada.Cells["Bairro"].Value.ToString();
                txtCidade.Text = linhaSelecionada.Cells["Cidade"].Value.ToString();
                txtUf.Text = linhaSelecionada.Cells["Estado"].Value.ToString();
                txtCep.Text = linhaSelecionada.Cells["Cep"].Value.ToString();
                txtEmail.Text = linhaSelecionada.Cells["Email"].Value.ToString();

                // Desativa o botão btnSave
                btnSave.Enabled = false;
            }
        }
    }


}
