using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarDadosDoBanco.Modelos
{
    public class SubCategoriaConsultarDespesa
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [ForeignKey(nameof(CategoriaConsultarDespesaId))]
        public int CategoriaConsultarDespesaId { get; set; }

        [NotMapped]
        public string NomeDaCategoria { get; set; }

        public virtual CategoriaConsultarDespesa CategoriaConsultarDespesa { get; set; }
    }
}
