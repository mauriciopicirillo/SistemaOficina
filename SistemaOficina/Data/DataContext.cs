using Microsoft.EntityFrameworkCore;
using SistemaOficina.Models;

namespace SistemaOficina.Data
{
    public class DataContext : DbContext
    {
        // Configurar a string de conexão para o MySQL
        private const string ConnectionString = "Server=localhost;Port=3306;Database=dboficina;User=root;Password=;";

        // Mapear a entidade Users para a tabela Users no esquema dboficina
        public DbSet<User> TbUsuarios { get; set; }
        public DbSet<Cliente> TbClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a chave primária para a entidade Users
            modelBuilder.Entity<User>().HasKey(u => u.IdUser);

            // Configurar a chave primária para a entidade Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.Idcli);
        }

        public void AdicionarCliente(Cliente novoCliente)
        {
            try
            {
                // Adicionar um novo cliente ao contexto e salvar as alterações no banco de dados
                TbClientes.Add(novoCliente);
                SaveChanges();
            }
            catch (Exception ex)
            {
                // Lidar com a exceção e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirCliente(int idCliente)
        {
            try
            {
                // Encontrar o cliente existente no contexto
                var clienteExistente = TbClientes.Find(idCliente);

                if (clienteExistente != null)
                {
                    // Solicitar confirmação do usuário antes de excluir
                    var confirmacao = MessageBox.Show("Tem certeza de que deseja excluir este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacao == DialogResult.Yes)
                    {
                        // Iniciar transação (opcional, dependendo do contexto do banco de dados)
                        using (var transaction = Database.BeginTransaction())
                        {
                            try
                            {
                                // Remover o cliente do contexto e salvar as alterações no banco de dados
                                TbClientes.Remove(clienteExistente);
                                SaveChanges();

                                // Commit da transação (opcional, dependendo do contexto do banco de dados)
                                transaction.Commit();

                                MessageBox.Show("Cliente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                // Rollback da transação em caso de falha (opcional, dependendo do contexto do banco de dados)
                                transaction.Rollback();

                                // Lidar com a exceção e exibir uma mensagem para o usuário
                                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    // Cliente não encontrado, exibir uma mensagem para o usuário
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lidar com a exceção global e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AdicionarUsuario(User novoUsuario)
        {
            try
            {
                // Adicionar um novo usuário ao contexto e salvar as alterações no banco de dados
                TbUsuarios.Add(novoUsuario);
                SaveChanges();
            }
            catch (Exception ex)
            {
                // Lidar com a exceção e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro ao adicionar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizarUsuario(int idUsuario, User usuarioAtualizado)
        {
            try
            {
                // Encontrar o usuário existente no contexto
                var usuarioExistente = TbUsuarios.Find(idUsuario);

                if (usuarioExistente != null)
                {
                    // Atualizar as propriedades do usuário existente com as do usuário atualizado
                    Entry(usuarioExistente).CurrentValues.SetValues(usuarioAtualizado);
                    SaveChanges();
                }
                else
                {
                    // Usuário não encontrado, exibir uma mensagem para o usuário
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lidar com a exceção e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirUsuario(int idUsuario)
        {
            try
            {
                // Encontrar o usuário existente no contexto
                var usuarioExistente = TbUsuarios.Find(idUsuario);

                if (usuarioExistente != null)
                {
                    // Remover o usuário do contexto e salvar as alterações no banco de dados
                    TbUsuarios.Remove(usuarioExistente);
                    SaveChanges();
                }
                else
                {
                    // Usuário não encontrado, exibir uma mensagem para o usuário
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Lidar com a exceção e exibir uma mensagem para o usuário
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
    


