using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarBancoDados.Modelos
{
    public class SubCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public int CategoriaId { get; set; }

        [NotMapped]
        public string NomeDaCategoria { get; set; }

        [NotMapped]
        public int FiltrarCategoriaId { get; set; }

        [NotMapped]
        public string NomeDoFiltro { get; set; }

        public SubCategoria() { }

        //Carregar ComboBox
        public SubCategoria(int id, string nomeDaSubCategoria, int categoriaId)
        {
            Id = id;
            NomeDaSubCategoria = nomeDaSubCategoria;
            CategoriaId = categoriaId;
        }

        //Carregar DataGrid
        public SubCategoria(int id, string nomeDaSubCategoria, int categoriaId, string nomeDaCategoria, int filtrarCategoriaId, string nomeDoFiltro)
        {
            Id = id;
            NomeDaSubCategoria = nomeDaSubCategoria;
            CategoriaId = categoriaId;
            NomeDaCategoria = nomeDaCategoria;
            FiltrarCategoriaId = filtrarCategoriaId;
            NomeDoFiltro = nomeDoFiltro;
        }

        public virtual Categoria Categoria { get; set; }
    }
}
