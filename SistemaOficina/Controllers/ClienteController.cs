using SistemaOficina.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms; // Adicione esta linha

namespace SistemaOficina.Controllers
{
    [Table("tbclientes")]
    internal class ClienteController
    {
        private readonly DataContext dataContext;

        public ClienteController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // Método para salvar um novo cliente
        public void SalvarCliente(string nome, string cpf, string telefone, string endereco,
                                  string numero, string bairro, string cidade, string uf, string cep, string email)
        {
            try
            {
                // Adicione lógica de validação, se necessário
                Models.Cliente novoCliente = new Models.Cliente(nome, cpf, telefone, endereco, numero,
                                                                bairro, cidade, uf, cep, email);

                // Adicione lógica para adicionar o cliente ao banco de dados
                dataContext.AdicionarCliente(novoCliente);

                // Exibe a MessageBox de sucesso
                MessageBox.Show($"Cliente {nome} foi adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Exibe a MessageBox de erro com informações adicionais da exceção interna
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}\n\nDetalhes da exceção interna: {ex.InnerException?.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar um cliente existente
        public void AtualizarCliente(int idCliente, string nome, string cpf, string telefone, string endereco,
                                     string numero, string bairro, string cidade, string uf, string cep, string email)
        {
            try
            {
                // Adicione lógica de validação, se necessário
                Models.Cliente clienteAtualizado = new Models.Cliente(nome, cpf, telefone, endereco, numero,
                                                                      bairro, cidade, uf, cep, email);

                // Adicione lógica para atualizar o cliente no banco de dados
                dataContext.AtualizarCliente(idCliente, clienteAtualizado);
            }
            catch (Exception ex)
            {
                // Trate a exceção de acordo com as necessidades do seu aplicativo
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        // Método para excluir um cliente
        public void ExcluirCliente(int idCliente)
        {
            try
            {
                // Adicione lógica para excluir o cliente do banco de dados
                dataContext.ExcluirCliente(idCliente);
            }
            catch (Exception ex)
            {
                // Trate a exceção de acordo com as necessidades do seu aplicativo
                Console.WriteLine($"Erro ao excluir cliente: {ex.Message}");
            }
        }
    }
}

