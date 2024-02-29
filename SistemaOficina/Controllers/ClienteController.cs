using SistemaOficina.Data;
using SistemaOficina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficina.Controllers
{
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
            }
            catch (Exception ex)
            {
                // Trate a exceção de acordo com as necessidades do seu aplicativo
                Console.WriteLine($"Erro ao salvar cliente: {ex.Message}");
            }
        }

        // Método para atualizar um cliente existente
        public void AtualizarCliente(int idCliente, string nome, string cpf, string telefone, string endereco,
                                     string numero, string bairro, string cidade, string uf, string cep, string email)
        {
            try
            {
                // Adicione lógica de validação, se necessário
                Models.Cliente clienteAtualizado = new Models.Cliente(idCliente, nome, cpf, telefone, endereco, numero,
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

