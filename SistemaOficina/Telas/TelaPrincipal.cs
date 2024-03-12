using SistemaOficina.Controllers;
using SistemaOficina.Data;

namespace SistemaOficina.Telas
{
    public partial class TelaPrincipal : Form
    {
        private ClienteController clienteController;
        private bool confirmacaoExibida = false;
        private int clienteIdSelecionado = -1;


        public TelaPrincipal()
        {
            InitializeComponent();

            DataContext dataContext = new DataContext();
            clienteController = new ClienteController(dataContext);


            // Adiciona o manipulador de evento para o evento FormClosing
            this.FormClosing += TelaPrincipal_FormClosing;
        }

        private void tabOrcamentos_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        // Iniicio dos métodos da Aba Cliente

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

        /// Método para preencher os campos com os dados da linha selecionada e desativar btnSave
        private void PreencherCamposComDadosDaLinhaSelecionada()
        {
            // Verifica se há pelo menos uma linha selecionada
            if (dtgClientes.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = dtgClientes.SelectedRows[0];

                // Preenche os campos de texto com os dados da linha selecionada
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

                // Atualiza o ID do cliente selecionado
                clienteIdSelecionado = Convert.ToInt32(linhaSelecionada.Cells["Idcli"].Value);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Obter os valores atualizados dos campos
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

            // Chamar o método AtualizarCliente do ClienteController
            clienteController.AtualizarCliente(clienteIdSelecionado, nome, cpf, telefone, endereco,
                                               numero, bairro, cidade, estado, cep, email);

            // Atualizar o dataGridView após a edição
            AtualizarDataGridViewPorCPF(txtPesquisa.Text);
            LimparCampos();

            // Ativar o botão btnSave novamente
            btnSave.Enabled = true;
        }

        // Método para validar campos obrigatórios
        private bool CamposValidos(string nome, string telefone)
        {
            return !string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(telefone);
        }

        private void TelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verifica se a mensagem de confirmação já foi exibida
            if (!confirmacaoExibida && e.CloseReason == CloseReason.UserClosing)
            {
                confirmacaoExibida = true; // Define a variável como verdadeira para indicar que a confirmação foi exibida
                if (MessageBox.Show("Deseja realmente sair do programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Se o usuário clicar em "Não", cancela o evento de fechamento
                    e.Cancel = true;
                    confirmacaoExibida = false; // Reseta a variável se o fechamento for cancelado
                }
            }
            // Não é necessário mais a verificação da variável confirmacaoExibida
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há um cliente selecionado
                if (clienteIdSelecionado != -1)
                {
                    // Chama o método ExcluirCliente usando a instância existente na TelaPrincipal
                    clienteController.ExcluirCliente(clienteIdSelecionado);

                    // Atualiza o dataGridView após a exclusão
                    AtualizarDataGridViewPorCPF(txtPesquisa.Text);

                    // Limpa os campos após a exclusão
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Selecione um cliente para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, se necessário
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Fim dos métodos da Aba Cliente


        //Inicio dos métodos da Aba Orçamentos

        private void txtPesCli_TextChanged(object sender, EventArgs e)
        {
            // Obtém o texto do campo txtPesCli
            string cpfPesquisa = txtPesCli.Text;

            // Chama o método do controlador para pesquisar e atualizar o dataGridView
            AtualizarDataGridViewPorCPFOrçamentos(cpfPesquisa);
        }

        private void AtualizarDataGridViewPorCPFOrçamentos(string cpf)
        {
            // Chama o método do controlador para pesquisar na tabela tbclientes e obter apenas os campos desejados
            var resultados = clienteController.PesquisarPorCPFOrçamentos(cpf);

            // Antes de atribuir a origem de dados
            dtgCli.AutoGenerateColumns = false;

            // Mapeia os campos do DataGridView para os campos da tabela tbclientes
            dtgCli.Columns["ColIdCli"].DataPropertyName = "Idcli";
            dtgCli.Columns["ColNomeCli"].DataPropertyName = "Nome";
            dtgCli.Columns["ColFoneCli"].DataPropertyName = "Fone";

            // Atualiza o dataGridView com os resultados da pesquisa
            dtgCli.DataSource = resultados;
        }

        private void dtgCli_SelectionChanged(object sender, EventArgs e)
        {
            PreencherCamposOrçamentosComDadosDaLinhaSelecionada();
        }

        private void PreencherCamposOrçamentosComDadosDaLinhaSelecionada()
        {
            // Verifica se há pelo menos uma linha selecionada
            if (dtgCli.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = dtgCli.SelectedRows[0];

                // Preenche os campos de texto com os dados da linha selecionada
                txtIdCli.Text = linhaSelecionada.Cells["ColIdCli"].Value.ToString();
                txtNomeCli.Text = linhaSelecionada.Cells["ColNomeCli"].Value.ToString();
                txtFoneCli.Text = linhaSelecionada.Cells["ColFoneCli"].Value.ToString();
            }
        }

        
    }
}
