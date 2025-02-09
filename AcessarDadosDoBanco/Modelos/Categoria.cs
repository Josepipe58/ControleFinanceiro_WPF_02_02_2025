using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }

        [ForeignKey(nameof(FiltrarCategoriaId))]
        public int FiltrarCategoriaId { get; set; }

        [NotMapped]
        public string NomeDoFiltro { get; set; }

        public Categoria() { }

        public Categoria(int id, string nomeDaCategoria, int filtrarCategoriaId, string nomeDoFiltro)
        {
            Id = id;
            NomeDaCategoria = nomeDaCategoria;
            FiltrarCategoriaId = filtrarCategoriaId;
            NomeDoFiltro = nomeDoFiltro;
        }

        public virtual FiltrarCategoria FiltrarCategoria { get; set; }
    }
}
