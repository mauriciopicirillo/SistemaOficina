using Microsoft.EntityFrameworkCore;
using SistemaOficina.Models;

namespace SistemaOficina.Data
{
    public class DataContext : DbContext
    {
        // Configurar a string de conexão para o MySQL
        private const string ConnectionString = "Server=localhost;Port=3306;Database=dboficina;User=root;Password=admin;";

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

        internal void AdicionarCliente(Cliente novoCliente)
        {
            // Adicionar um novo cliente ao contexto e salvar as alterações no banco de dados
            TbClientes.Add(novoCliente);
            SaveChanges();
        }

        internal void AtualizarCliente(int idCliente, Cliente clienteAtualizado)
        {
            // Encontrar o cliente existente no contexto
            var clienteExistente = TbClientes.Find(idCliente);

            if (clienteExistente != null)
            {
                // Atualizar as propriedades do cliente existente com as do cliente atualizado
                Entry(clienteExistente).CurrentValues.SetValues(clienteAtualizado);
                SaveChanges();
            }
            else
            {
                // Cliente não encontrado, pode lançar uma exceção ou lidar de acordo com os requisitos
            }
        }

        internal void ExcluirCliente(int idCliente)
        {
            // Encontrar o cliente existente no contexto
            var clienteExistente = TbClientes.Find(idCliente);

            if (clienteExistente != null)
            {
                // Remover o cliente do contexto e salvar as alterações no banco de dados
                TbClientes.Remove(clienteExistente);
                SaveChanges();
            }
            else
            {
                // Cliente não encontrado, pode lançar uma exceção ou lidar de acordo com os requisitos
            }
        }
    }
}