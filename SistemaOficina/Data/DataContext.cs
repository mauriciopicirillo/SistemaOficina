using Microsoft.EntityFrameworkCore;
using SistemaOficina.Models;

namespace SistemaOficina.Data
{
    public class DataContext : DbContext
    {
        // Caminho da conexão com o banco de dados
        private const string ConnectionString = "Data Source=DESKTOP-2LFAP3R\\SQLEXPRESS;Initial Catalog=dboficina;User ID=sa;Password=admin;TrustServerCertificate=True";

        // Mapeie a entidade Users para a tabela Users no esquema dboficina
        public DbSet<User> Tbusuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a chave primária para a entidade Users
            modelBuilder.Entity<User>().HasKey(u => u.IdUser);

            // Configurando a chave primária para a entidade Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.Idcli);
        }

        internal void AdicionarCliente(Cliente novoCliente)
        {
            // Adiciona um novo cliente ao contexto e salva as alterações no banco de dados
            Clientes.Add(novoCliente);
            SaveChanges();
        }

        internal void AtualizarCliente(int idCliente, Cliente clienteAtualizado)
        {
            // Encontra o cliente existente no contexto
            var clienteExistente = Clientes.Find(idCliente);

            if (clienteExistente != null)
            {
                // Atualiza as propriedades do cliente existente com as do cliente atualizado
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
            // Encontra o cliente existente no contexto
            var clienteExistente = Clientes.Find(idCliente);

            if (clienteExistente != null)
            {
                // Remove o cliente do contexto e salva as alterações no banco de dados
                Clientes.Remove(clienteExistente);
                SaveChanges();
            }
            else
            {
                // Cliente não encontrado, pode lançar uma exceção ou lidar de acordo com os requisitos
            }
        }
    }
}