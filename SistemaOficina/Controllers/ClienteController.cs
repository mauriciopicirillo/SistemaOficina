using Microsoft.EntityFrameworkCore;
using SistemaOficina.Data;
using SistemaOficina.Models;

namespace SistemaOficina.Controllers
{
    public class ClienteController
    {
        private readonly DataContext dataContext;

        public ClienteController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public ClienteController()
        {
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

        public void AtualizarCliente(int idCliente, string nome, string cpf, string telefone, string endereco,
                             string numero, string bairro, string cidade, string estado, string cep, string email)
        {
            try
            {
                // Encontrar o cliente existente no contexto
                var clienteExistente = dataContext.TbClientes.Find(idCliente);

                if (clienteExistente != null)
                {
                    // Atualizar as propriedades do cliente existente com os novos valores
                    clienteExistente.Nome = nome;
                    clienteExistente.Cpf = cpf;
                    clienteExistente.Fone = telefone;
                    clienteExistente.End = endereco;
                    clienteExistente.Numero = numero;
                    clienteExistente.Bairro = bairro;
                    clienteExistente.Cidade = cidade;
                    clienteExistente.Estado = estado;
                    clienteExistente.Cep = cep;
                    clienteExistente.Email = email;

                    // Salvar as alterações no banco de dados
                    dataContext.SaveChanges();

                    MessageBox.Show("Cliente atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cliente não encontrado, exibir uma mensagem para o usuário
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lidar com a exceção e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro ao atualizar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public List<Cliente> PesquisarPorCPF(string cpf)
        {
            try
            {
                // Utiliza LINQ para pesquisar no DbSet com base no CPF
                var resultados = dataContext.TbClientes
                    .Where(c => c.Cpf.Contains(cpf))
                    .ToList();

                return resultados;
            }
            catch (Exception ex)
            {
                // Trate a exceção de acordo com as necessidades do seu aplicativo
                Console.WriteLine($"Erro ao pesquisar por CPF: {ex.Message}");
                return new List<Cliente>();
            }
        }

        public List<Cliente> PesquisarPorCPFOrçamentos(string cpf)
        {
            try
            {
                // Utilize LINQ para pesquisar no DbSet com base no CPF
                var resultados = dataContext.TbClientes
                    .Where(c => c.Cpf.Contains(cpf))
                    .Select(c => new Cliente
                    {
                        Idcli = c.Idcli,
                        Nome = c.Nome,
                        Fone = c.Fone
                    })
                    .ToList();

                return resultados;
            }
            catch (Exception ex)
            {
                // Trate a exceção de acordo com as necessidades do seu aplicativo
                Console.WriteLine($"Erro ao pesquisar por CPF (Orçamentos): {ex.Message}");
                return new List<Cliente>();
            }
        }
    }
}