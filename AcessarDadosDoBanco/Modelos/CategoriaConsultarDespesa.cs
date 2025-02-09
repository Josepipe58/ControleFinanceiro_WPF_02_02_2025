using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Modelos
{
    public class CategoriaConsultarDespesa
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }
    }
}
