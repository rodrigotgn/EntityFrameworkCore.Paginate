using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.UsePaginateTest.Repository
{
    public class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// ApplicationDBContext
        /// </summary>
        /// <remarks>
        /// Construtor do Contexto do Banco de Dados através do Entity Framework Core.
        /// </remarks>
        public ApplicationDBContext() { }

        /// <summary>
        /// ApplicationDBContext
        /// </summary>
        /// <remarks>
        /// Construtor do Contexto do Banco de Dados através do Entity Framework Core.
        /// </remarks>
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// User
        /// </summary>
        /// <remarks>
        /// Propriedade representativa da Tabela de Contexto do Banco de Dados através do Entity Framework Core (Tabela: Usuário).
        /// </remarks>
        public DbSet<Models.User> User { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <remarks>
        /// Realiza as Configurãções do Contexto do Banco de Dados através do Entity Framework Core através das classes de configuração de cada entidade.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <remarks>
        /// Realiza as demais configurãções ("exemplo: conexão com o banco de dados") do Contexto do Banco de Dados através do Entity Framework Core.
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
