using Microsoft.EntityFrameworkCore;
using SistemaOficina.Data;
using System;

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
        public string SalvarCliente(string nome, string cpf, string telefone, string endereco,
                                    string numero, string bairro, string cidade, string estado, string cep, string email)
        {
            try
            {
                // Validar se nome, cpf e telefone estão preenchidos
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(telefone))
                {
                    return "Nome, CPF e telefone são campos obrigatórios.";
                }

                Models.Cliente novoCliente = new Models.Cliente(nome, cpf, telefone, endereco,
                                                                numero, bairro, cidade, estado, cep, email);

                // Adiciona o novo cliente ao contexto
                dataContext.AdicionarCliente(novoCliente);

                // Tenta salvar as alterações no banco de dados
                dataContext.SaveChanges();

                return $"Cliente {nome} foi adicionado com sucesso.";
            }
            catch (DbUpdateException ex)
            {
                // Captura exceções específicas do Entity Framework
                Console.WriteLine($"Erro do Entity Framework ao salvar alterações: {ex.Message}");
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    Console.WriteLine($"Detalhes da exceção interna: {ex.InnerException.InnerException.Message}");
                }

                return $"Erro ao salvar cliente: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Captura outras exceções
                Console.WriteLine($"Erro ao salvar cliente: {ex.Message}");
                return $"Erro ao salvar cliente: {ex.Message}";
            }
        }

        // Método para atualizar um cliente existente
        public string AtualizarCliente(int idCliente, string nome, string cpf, string telefone, string endereco,
                                       string numero, string bairro, string cidade, string uf, string cep, string email)
        {
            try
            {
                
                Models.Cliente clienteAtualizado = new Models.Cliente(nome, cpf, telefone, endereco, numero,
                                                                      bairro, cidade, uf, cep, email);

                
                dataContext.AtualizarCliente(idCliente, clienteAtualizado);

                return $"Cliente {nome} foi atualizado com sucesso.";
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
                return $"Erro ao atualizar cliente: {ex.Message}";
            }
        }

        // Método para excluir um cliente
        public string ExcluirCliente(int idCliente)
        {
            try
            {
                // Adicione lógica para excluir o cliente do banco de dados
                dataContext.ExcluirCliente(idCliente);

                return "Cliente excluído com sucesso.";
            }
            catch (Exception ex)
            {
                // Logue a exceção ou retorne uma mensagem específica
                Console.WriteLine($"Erro ao excluir cliente: {ex.Message}");
                return $"Erro ao excluir cliente: {ex.Message}";
            }
        }
    }
}