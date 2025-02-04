using AcessarBancoDados.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace AcessarBancoDados.ContextoDeDados
{
    public class Contexto : DbContext
    {
        public Contexto() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Ano> TAno { get; set; }
        public virtual DbSet<FiltrarCategoria> TFiltrarCategoria { get; set; }
        public virtual DbSet<Categoria> TCategoria { get; set; }
        public virtual DbSet<SubCategoria> TSubCategoria { get; set; }
        public virtual DbSet<Despesa> TDespesa { get; set; }
        public virtual DbSet<Poupanca> TPoupanca { get; set; }
        public virtual DbSet<Receita> TReceita { get; set; }
        public virtual DbSet<Investimento> TInvestimento { get; set; }
        public virtual DbSet<Aposentadoria> TAposentadoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(" Data Source = JOSEPIPE-PC\\FINANCEIRO; Initial Catalog = Financeiro_2025_2040; " +
                    "Integrated Security = True; TrustServerCertificate=True");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                return;
            }
        }
    }
}
