using System.ComponentModel.DataAnnotations;

namespace AcessarBancoDados.Modelos
{
    public class CategoriaConsultarDespesa
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }
    }
}
